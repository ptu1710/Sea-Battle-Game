using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleships
{
    public class Network
    {
        private IPAddress host = null;

        private int port = 2006;

        public TcpClient tcpClient = null;

        StreamWriter sw = null;

        public static loginForm loginForm = null;

        public static MainMenu mainMenu = null;

        public static ShipDeployment DeployShip = null;

        public static PlayForm playForm = null;

        public Network(string ip, int _port)
        {
            this.host = IPAddress.Parse(ip);
            this.port = _port;
        }

        public bool Connect()
        {
            try
            {
                tcpClient = new TcpClient();
                tcpClient.Connect(new IPEndPoint(host, port));
                sw = new StreamWriter(tcpClient.GetStream()) { AutoFlush = true };

                Thread listen = new Thread(Run);
                listen.Start();

                return true;
            }
            catch
            {
                Console.WriteLine("Here");
                return false;
            }
        }

        private void Run()
        {
            StreamReader sr = new StreamReader(tcpClient.GetStream());
            try
            {
                while (tcpClient.Connected)
                {
                    string rawMsg = sr.ReadLine();

                    ReceiveMsg(rawMsg);
                }
            }
            catch
            {
                tcpClient.Close();
                sr.Close();
            }
        }

        private void ReceiveMsg(string rawMsg)
        {
            try
            {
                if (string.IsNullOrEmpty(rawMsg))
                {
                    return;
                }

                string[] msgPayload = rawMsg.Split('|');

                int code = int.Parse(msgPayload[0]);

                string cName = msgPayload[1];

                if (code == 0)
                {
                    string msg = msgPayload[2];

                    loginForm.UpdateForm(msg, cName, msgPayload[3]);
                }
                else if (code == 1)
                {
                    string roomID = msgPayload[1];
                    string otherUser = msgPayload[2];

                    if (otherUser == "")
                    {
                        MessageBox.Show("This room is currently full!", $"Cannot join to room", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                    else if (otherUser != Game.me.cName)
                    {
                        Game.player = new Player(otherUser);
                        Game.player.roomID = roomID;

                        mainMenu.UpdateForm(1, roomID, otherUser);
                    }
                    else
                    {
                        mainMenu.UpdateForm(1, roomID, "");
                    }

                    Game.me.roomID = roomID;
                }
                else if (code == 2)
                {
                    string playerTurn = msgPayload[2];

                    if (playerTurn == Game.me.cName)
                    {
                        Game.me.isMyTurn = true;
                    }
                    else
                    {
                        Game.me.isMyTurn = false;
                    }
                }
                else if (code == 3)
                {
                    string from = msgPayload[1].Split(':')[1];

                    var coor = msgPayload[2].Split(':');

                    int x = int.Parse(coor[0]);
                    int y = int.Parse(coor[1]);

                    int length = int.Parse(coor[2]);

                    playForm.PerformAttacked(from, x, y, length);
                }
                else if (code == 4)
                {
                    string userWin = msgPayload[2];

                    playForm.PerformWin(userWin, playForm);
                }
                else if (code == 5)
                {
                    mainMenu.UpdateForm(5, "", msgPayload[2]);
                }
                else if (code == 6)
                {
                    DeployShip.startGame(DeployShip);
                }
                else if (code == 7)
                {
                    playForm.PerformWin(cName, playForm);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("getMsg " + ex.Message);
            }
        }

        public void SendMsg(int code, string msg = "", string msg1 = "", string msg2 = "")
        {
            string formatedMsg = $"{code}|{msg}|{msg1}|{msg2}";
            
            if (sw != null)
            {
                sw.WriteLine(formatedMsg);
            }
        }

        public void SendMove(int code, string roomID, string from, int x, int y)
        {
            string formatedMsg = $"{code}|{roomID}:{from}|{x}:{y}";

            if (sw != null)
            {
                sw.WriteLine(formatedMsg);
            }
        }

        public void SendPlayerInfo(Player player, string roomID)
        {
            SendMsg(2, Game.me.cName, roomID);

            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(tcpClient.GetStream(), player.ShipSet);
        }
    }
}
