using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Battleships
{
    public class Network
    {
        ModifyDB modify = new ModifyDB();

        private readonly int port = 2006;

        public IPAddress IP { get; set; }

        private TcpListener tcpListener = null;

        public bool IsListening { get; set; }

        mainForm mainForm = null;

        public Network()
        {
            this.IP = null;
        }

        public Network(mainForm form)
        {
            this.mainForm = form;
        }

        public void Run()
        {
            try
            {
                tcpListener = new TcpListener(new IPEndPoint(IP, port));
                tcpListener.Start();

                while (IsListening)
                {
                    TcpClient client = tcpListener.AcceptTcpClient();
                    Thread clientThread = new Thread(() => Listen(client));
                    clientThread.Start();
                    mainForm.UpdateLog($"Accept from {client.Client.RemoteEndPoint}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Server - run(): {ex.Message}");
            }
        }

        public void Listen(TcpClient client)
        {
            StreamReader sr = new StreamReader(client.GetStream());

            //try
            //{
            while (IsListening && client.Connected)
            {
                string recvMsg = sr.ReadLine();

                if (string.IsNullOrEmpty(recvMsg))
                {
                    continue;
                }

                string[] msgPayload = recvMsg.Split('|');

                int code = int.Parse(msgPayload[0]);

                if (code == 0)
                {
                    string user = msgPayload[1];
                    string pass = msgPayload[2];

                    string query = "SELECT * FROM Accounts WHERE TenTK='" + user + "' AND MK='" + pass + "'";

                    if (modify.Accounts(query).Count > 0)
                    {
                        if (Game.currentTCPs.ContainsKey(user))
                        {
                            sendFailedLogin(0, user, client, "existed");
                            mainForm.UpdateLog($"Login failed: {user} is currently logged in");
                            continue;
                        }
                        else
                        {
                            Game.currentTCPs.Add(user, client);
                            Game.currentUsers.Add(user, new Player(user));

                            sendMsg(0, user, "success");
                            mainForm.UpdateLog($"Signed in successfully: {user}/{pass}");
                        }
                    }
                    else
                    {
                        sendFailedLogin(0, user, client, "failed");
                        mainForm.UpdateLog($"Login failed: {user}/{pass} does not exist");
                    }
                }
                else if (code == 1)
                {
                    string user = msgPayload[1];
                    string roomID = msgPayload[2];

                    if (string.IsNullOrEmpty(roomID))
                    {
                        roomID = Game.RandomRoomID();
                        Room room = new Room(roomID, user);

                        Game.rooms.Add(roomID, room);

                        mainForm.UpdateLog($"Create room {roomID} for player {user}");
                    }
                    else
                    {
                        Game.rooms[roomID].AddPlayer(user, Game.currentUsers[user]);

                        mainForm.UpdateLog($"Player {user} joined {roomID}");
                    }

                    foreach (string sendto in Game.rooms[roomID].Users.Keys)
                    {
                        sendToRoom(1, roomID, sendto);
                    }
                }
                else if (code == 2)
                {
                    string user = msgPayload[1];
                    string roomID = msgPayload[2];

                    getPlayer(user, roomID);
                    mainForm.UpdateLog($"Player {user} is ready");

                    sendToRoom(2, roomID, Game.rooms[roomID].playerTurn);
                }
                else if (code == 3)
                {
                    string roomID = msgPayload[1].Split(':')[0];
                    string from = msgPayload[1].Split(':')[1];

                    var coor = msgPayload[2].Split(':');

                    int x = int.Parse(coor[0]);
                    int y = int.Parse(coor[1]);

                    int shipLength = Game.PerformAttack(x, y, roomID, from);

                    sendMove(3, from, roomID, x, y, shipLength);

                    Game.rooms[roomID].ChangePlayerTurn(from);
                    sendToRoom(2, roomID, Game.rooms[roomID].playerTurn);

                    mainForm.UpdateLog($"Player {from} was attacked at {x}:{y}:{shipLength}");

                    //if (Game.IsSunkenShip(x, y, roomID, from) != -1)
                    //{
                    //    sendToRoom(5, roomID, $"{x}:{y}:{Game.IsSunkenShip(x, y, roomID, from)}");
                    //}    

                    if (Game.IsEndGame(roomID, from))
                    {
                        sendToRoom(4, roomID, from);
                    }
                }
                else if (code == 6)
                {
                    string roomID = msgPayload[1];
                    string user = msgPayload[2];

                    Room room = Game.rooms[roomID];
                    int index = room.Users.Keys.ToList().IndexOf(user);
                    room.isPlaying[index] = true;

                    if (!room.isPlaying.Contains(false))
                    {
                        //
                        sendToRoom(6, roomID);
                    }
                }
            }
            //}
            //catch
            //{
            //    Console.WriteLine("Error at: FromClient()");
            //    client.Close();
            //    sr.Close();
            //}
            // sr.Close();
        }

        // Check 
        private void sendMsg(int code, string user, string msg)
        {
            string formattedMsg = $"{code}|{user}|{msg}";

            StreamWriter sw = new StreamWriter(Game.currentTCPs[user].GetStream()) { AutoFlush = true };

            if (sw != null)
            {
                sw.WriteLine(formattedMsg);
            }
        }

        private void sendFailedLogin(int code, string user, TcpClient client, string msg)
        {
            string formattedMsg = $"{code}|{user}|{msg}";

            StreamWriter sw = new StreamWriter(client.GetStream()) { AutoFlush = true };

            if (sw != null)
            {
                sw.WriteLine(formattedMsg);
            }
        }

        private void sendMove(int code , string from, string roomID, int x, int y, int length)
        {
            string formattedMsg = $"{x}:{y}:{length}";

            sendToRoom(code, $"{roomID}:{from}", formattedMsg);
        }

        private void sendToRoom(int code, string roomID_And_User, string msg = "")
        {
            string formattedMsg = $"{code}|{roomID_And_User}|{msg}";

            string roomID = roomID_And_User.Split(':')[0];

            foreach (string playerName in Game.rooms[roomID].Users.Keys)
            {
                StreamWriter sw = new StreamWriter(Game.currentTCPs[playerName].GetStream()) { AutoFlush = true };
                if (sw != null)
                {
                    sw.WriteLine(formattedMsg);
                }
            }
        }

        private void getPlayer(string username, string roomID)
        {
            BinaryFormatter bf = new BinaryFormatter();
            int[,] playerShipSet = (int[,])bf.Deserialize(Game.currentTCPs[username].GetStream());

            Player player = Game.currentUsers[username];
            player.setShipSet(playerShipSet);

            Room room = Game.rooms[roomID];
            room.AddPlayer(username, player);
        }

        /// <summary>
        /// Get IPv4 in use
        /// </summary>
        /// <param name="_type"></param>
        /// <returns></returns>
        public static string GetIPAddress(NetworkInterfaceType _type)
        {
            string returnIP = "";

            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up
                    && (item.Name == "Ethernet" || item.Name == "Wi-Fi"))
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            Console.WriteLine(ip.Address);
                            returnIP = ip.Address.ToString();
                        }
                    }
                }
            }

            return returnIP;
        }
    }
}
