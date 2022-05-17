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

        TcpClient client;

        private readonly int _port = 2006;

        public IPAddress _iPAddress { get; set; }

        private TcpListener tcpListener = null;

        public bool isListening { get; set; }

        public Network()
        {
            this._iPAddress = null;
        }

        public Network(string ip)
        {
            this._iPAddress = IPAddress.Parse(ip);
        }

        public Network(TcpClient tcpClient)
        {
            this.client = tcpClient;
        }

        // Get IPv4 in use
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

        public void Listen()
        {
            try
            {
                tcpListener = new TcpListener(new IPEndPoint(_iPAddress, _port));
                tcpListener.Start();

                while (isListening)
                {
                    client = tcpListener.AcceptTcpClient();

                    Thread clientThread = new Thread(() => FromClient());
                    clientThread.Start();
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void FromClient()
        {
            StreamReader sr = new StreamReader(client.GetStream());
            
            /*try
            {*/
                while (isListening && client.Connected)
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
                            mainForm.currentUsers.Add(new Player(user), client);
                            sendMsg(code, "success");
                        }
                        else
                        {
                            Console.WriteLine("Failed");
                        }
                    }
                    else if (code == 1)
                    {
                        string user = msgPayload[1];
                        getPlayer(user);
                    }
                }
            //}
            /*catch
            {
                Console.WriteLine("Error at: FromClient()");
                client.Close();
                sr.Close();
            }*/
            sr.Close();
        }

        private void sendMsg(int code, string msg)
        {
            string formattedMsg = $"{code}|{msg}";

            StreamWriter sw = new StreamWriter(client.GetStream()) { AutoFlush = true };

            sw.WriteLine(formattedMsg);
        }

        private void getPlayer(string username)
        {
            BinaryFormatter bf = new BinaryFormatter();
            int[,] playerShipSet = (int[,])bf.Deserialize(client.GetStream());
            
            foreach (Player player in mainForm.currentUsers.Keys)
            {
                if (player.name == username)
                {
                    player.setShipSet(playerShipSet);
                }
            }
        }
    }
}
