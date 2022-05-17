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
        private IPAddress _ip;

        private int _port;

        TcpClient tcpClient;

        StreamWriter sw;

        loginForm loginForm;

        // ComboBox.ObjectCollection ipCollection;

        public Network()
        {

        }

        public Network(loginForm login, string ip, int port)
        {
            this.loginForm = login;
            this._ip = IPAddress.Parse(ip);
            this._port = port;

            Connect();
        }

        public bool Connect()
        {
            try
            {
                tcpClient = new TcpClient();
                tcpClient.Connect(new IPEndPoint(_ip, _port));
                sw = new StreamWriter(tcpClient.GetStream()) { AutoFlush = true };

                Thread listenThread = new Thread(listen);
                listenThread.Start();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void CreateMsg()
        {

        }

        public void SendMsg(int code, string user = "", string pass = "", string email = "")
        {
            string formatedMsg = $"{code}|{user}|{pass}";

            if (sw != null)
            {
                sw.WriteLine(formatedMsg);
            }
        }

        public void SendPlayerInfo(Player player)
        {
            SendMsg(1);

            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(tcpClient.GetStream(), player.ShipSet);
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

                if (code == 0)
                {
                    // string msg = msgPayload[1];

                    UpdateForm();

                    /*MainMenu mainMenu = new MainMenu();
                    mainMenu.Show();*/

                    // Console.WriteLine(msg);
                }
                else if (code == 1)
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


        private delegate void SafeUpdateForm();

        private void UpdateForm()
        {
            if (loginForm.InvokeRequired)
            {
                var d = new SafeUpdateForm(UpdateForm);
                loginForm.Invoke(d, new object[] { });
            }
            else
            {
                loginForm.Hide();

                MainMenu mainMenu = new MainMenu();
                mainMenu.Show();
            }
        }
    }
}
