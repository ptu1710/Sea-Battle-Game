using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Battleships
{
    public class Network
    {
        private readonly int _port = 2006;

        public IPAddress _iPAddress { get; set; }

        private TcpListener tcpListener = null;

        public bool isListening { get; set; }

        public Network()
        {
            this._iPAddress = null;
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
                    Console.WriteLine(item.Name);
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
                    TcpClient _client = tcpListener.AcceptTcpClient();

                    Thread clientThread = new Thread(() => FromClient(_client));
                    clientThread.Start();
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void FromClient(TcpClient tcpClient)
        {
            StreamReader sr = new StreamReader(tcpClient.GetStream());
            
            try
            {
                while (isListening && tcpClient.Connected)
                {
                    string recvMsg = sr.ReadLine();

                    if (string.IsNullOrEmpty(recvMsg))
                    {
                        continue;
                    }

                    Console.WriteLine(recvMsg);

                    //string[] msgPayload = recvMsg.Split('|');

                    //int code = int.Parse(msgPayload[0]);
                    //string msg = msgPayload[1];
                    //string username = msgPayload[2];

                    //if (code == 0 || code == 1)
                    //{
                    //    if (code != 1)
                    //    {
                    //        if (msg == "disconnect")
                    //        {
                    //            tcpClient.Close();
                    //        }
                    //        else
                    //        {
                               
                    //        }
                    //    }
                    //}
                    //else if (code == 2 || code == 3)
                    //{
                    //    string to = msgPayload[3];

                    //    string log = code == 2 ? $"[{DateTime.Now:H:mm}] - {username} to {to}: {msg}" : $"[{DateTime.Now:H:mm}] - {username} send image {msg} to {to}";
                    //}
                    //else if (code == 4)
                    //{

                    //}
                }
            }
            catch
            {
                tcpClient.Close();
                sr.Close();
            }
            sr.Close();
        }
    }
}
