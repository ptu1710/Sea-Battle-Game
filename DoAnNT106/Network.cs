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

        loginForm loginForm = null;

        public static MainMenu mainMenu = null;

        public static PlayForm playForm = null;

        public Network(loginForm login, string ip, int _port)
        {
            this.loginForm = login;
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
/*            try
            {*/
                if (string.IsNullOrEmpty(rawMsg))
                {
                    return;
                }

                string[] msgPayload = rawMsg.Split('|');

                int code = int.Parse(msgPayload[0]);

                string cName = msgPayload[1];

                if (code == 0)
                {
                    loginForm.UpdateForm(cName);
                }
                else if (code == 1)
                {
                    string roomID = msgPayload[2];

                    Game.me.roomID = roomID;

                    mainMenu.UpdateForm(roomID);
                }
                else if (code == 2)
                {
                    
                }
                else if (code == 3)
                {
                    string roomID = msgPayload[1].Split(':')[0];
                    string user = msgPayload[1].Split(':')[1];

                    var coor = msgPayload[2].Split(':');

                    int x = int.Parse(coor[0]);
                    int y = int.Parse(coor[1]);

                    bool result = bool.Parse(coor[2]);

                    playForm.PerformAttacked(user, x, y, result);
                }
                else if (code == 4)
                {
                    string user = msgPayload[1];

                    MessageBox.Show("Nice!!!", $"{user} won!");
                }
/*            }
            catch (Exception ex)
            {
                MessageBox.Show("getMsg " + ex.Message);
            }*/
        }

        public void SendMsg(int code, string user = "", string pass_or_coor = "", string email = "")
        {
            string formatedMsg = $"{code}|{user}|{pass_or_coor}";
            
            if (sw != null)
            {
                sw.WriteLine(formatedMsg);
            }
        }

        public void SendMove(int code, string roomID, string user, int x, int y)
        {
            string formatedMsg = $"{code}|{roomID}:{user}|{x}:{y}";

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

        // Get Local IPv4 with specify _type
        public IPAddress GetIPAddress(NetworkInterfaceType _type)
        {
            IPAddress returnIP = IPAddress.None;

            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            returnIP = ip.Address;
                        }
                    }
                }
            }

            return returnIP;
        }
    }
}
