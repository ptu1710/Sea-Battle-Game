using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleships
{
    public class Network
    {
        private IPAddress _ip;

        private int _port;

        TcpClient tcpClient;

        Socket socket;

        StreamWriter sw;

        public Network()
        {

        }

        public Network(string ip, int port)
        {
            this._ip = IPAddress.Parse(ip);
            this._port = port;

            tcpClient = new TcpClient();
            //tcpClient.Connect(new IPEndPoint(_ip, _port));
            //sw = new StreamWriter(tcpClient.GetStream()) { AutoFlush = true };
        }

        public bool Connect()
        {


            return true;
        }

        public void CreateMsg()
        {

        }

        public void SendMsg(int code, string user, string pass, string email)
        {

        }

        private void listen()
        {
            StreamReader sr = new StreamReader(tcpClient.GetStream());
            try
            {
                while (tcpClient.Connected)
                {
                    string rawMsg = sr.ReadLine();

                    getMsg(rawMsg);
                }
            }
            catch
            {
                tcpClient.Close();
                sr.Close();
            }
        }

        private void getMsg(string rawMsg)
        {
            try
            {
                if (string.IsNullOrEmpty(rawMsg))
                {
                    return;
                }

                string[] msgPayload = rawMsg.Split('|');

                int code = int.Parse(msgPayload[0]);
                string msg = msgPayload[1];
                string from = msgPayload[2];

                if (code == 0)
                {
                    Console.WriteLine(rawMsg);

                    if (msg == "existed")
                    {
                        tcpClient.Close();
                        MessageBox.Show($"Username: has already existed, choose another one");
                    }
                    else if (msg == "disconnect")
                    {
                        // 
                    }
                }
                else if (code == 1)
                {
                    
                }
                else if (code == 2 || code == 3)
                {
                    
                }
                else if (code == 4)
                {
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("getMsg " + ex.Message);
            }
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
