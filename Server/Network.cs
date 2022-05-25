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
                        Game.currentUsers.Add(new Player(user), client);
                        sendMsg(code, user, "success");
                        mainForm.UpdateLog($"Signed in successfully: {user}/{pass}");
                    }
                    else
                    {
                        sendMsg(code, user, "failed");
                        mainForm.UpdateLog($"Login failed: {user}/{pass} does not exist");
                    }
                }
                else if (code == 1)
                {
                    // Game._ME.SendMsg(1, Game.me.cName, "");
                    string user = msgPayload[1];
                    string roomID = msgPayload[2];

                    bool flag = false;

                    if (string.IsNullOrEmpty(roomID))
                    {
                        roomID = Game.RandomRoomID();
                        Room room = new Room(roomID, new List<Player> { new Player(user) });
                        Game.rooms.Add(room);
                        flag = true;
                    }
                    else
                    {
                        foreach (Room room in Game.rooms)
                        {
                            if (room._id == roomID)
                            {
                                flag = true;
                                room.Users.Add(new Player(user));
                            }
                        }
                    }

                    if (flag)
                    {
                        sendMsg(code, user, roomID);
                    }
                    else
                    {
                        Console.WriteLine("No Room");
                    }
                }
                else if (code == 2)
                {
                    string user = msgPayload[1];
                    string roomID = msgPayload[2];

                    getPlayer(user, roomID);
                    mainForm.UpdateLog($"Player {user} is ready");
                }
                else if (code == 3)
                {
                    string roomID = msgPayload[1].Split(':')[0];
                    string user = msgPayload[1].Split(':')[1];

                    var coor = msgPayload[2].Split(':');

                    int x = int.Parse(coor[0]);
                    int y = int.Parse(coor[1]);

                    sendMove(code, roomID, user, x, y, mainForm.PerformAttack(x, y, user));
                    mainForm.UpdateLog($"Player {user} was attacked at {x}:{y}:{mainForm.PerformAttack(x, y, user)}");

                    if (mainForm.IsEndGame(user))
                    {
                        sendMsg(4, user, $"true");
                        mainForm.UpdateLog($"Player {user} won!");
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

            StreamWriter sw = null;

            foreach (Player player in Game.currentUsers.Keys)
            {
                if (player.cName == user)
                {
                    sw = new StreamWriter(Game.currentUsers[player].GetStream()) { AutoFlush = true };
                }
            }
            
            if (sw != null)
            {
                sw.WriteLine(formattedMsg);
            }
        }

        private void sendMove(int code, string roomID, string user, int x, int y, bool hit)
        {
            string formattedMsg = $"{code}|{roomID}:{user}|{x}:{y}:{hit}";

            StreamWriter sw = null;

            Room room = Game.rooms.Find(r => r._id == roomID);

            foreach (Player player in room.Users)
            {
                sw = new StreamWriter(Game.currentUsers[player].GetStream()) { AutoFlush = true };
            }

            if (sw != null)
            {
                sw.WriteLine(formattedMsg);
            }
        }


        private void getPlayer(string username, string roomID)
        {
            foreach (Player player in Game.currentUsers.Keys)
            {
                if (player.cName == username)
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    int[,] playerShipSet = (int[,])bf.Deserialize(Game.currentUsers[player].GetStream());

                    player.setShipSet(playerShipSet);

                    Room room = Game.rooms.Find(r => r._id == roomID);


                    for (int i = 0; i < room.Users.Count; i++)
                    {
                        if (room.Users[i].cName == player.cName)
                        {
                            room.Users[i] = player;
                        }
                    }
                }
            }
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
