using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleships
{
    public partial class mainForm : Form
    {
        readonly Network network = new Network();

        private bool isRunning = false;
        
        private bool isManualSetting = true;

        private Thread listenThread;

        public static Dictionary<Player, TcpClient> currentUsers = new Dictionary<Player, TcpClient>();

        public mainForm()
        {
            InitializeComponent();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            if (network._iPAddress == null)
            {
                MessageBox.Show("You are not connected to the Internet!");
                return;
            }

            if (!isRunning)
            {
                isRunning = true;

                network.isListening = true;

                listenThread = new Thread(network.Listen);
                listenThread.Start();

                Console.WriteLine("OK");

                startBtn.Enabled = false;
            }
        }

        private void mainForm_Shown(object sender, EventArgs e)
        {
            if (isManualSetting)
            {
                network._iPAddress = IPAddress.Parse("127.0.0.1");
                return;
            }

            string ip = Network.GetIPAddress(NetworkInterfaceType.Wireless80211);

            if (!string.IsNullOrEmpty(ip))
            {
                // is Wifi
                network._iPAddress = IPAddress.Parse(ip); 
            }
            else if (!string.IsNullOrEmpty(ip = Network.GetIPAddress(NetworkInterfaceType.Ethernet)))
            {
                // is Ethernet
                network._iPAddress = IPAddress.Parse(ip);
            }
        }
    }
}
