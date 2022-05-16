using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleships
{
    public partial class mainForm : Form
    {
        ModifyDB modify = new ModifyDB();

        readonly Network network = new Network();

        private bool isRunning = false;
        
        private bool isManualSetting = false;

        private Thread listenThread;

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

                MessageBox.Show("Start Listening");
                startBtn.Enabled = false;
            }
        }

        private void mainForm_Shown(object sender, EventArgs e)
        {
            if (isManualSetting)
            {
                network._iPAddress = IPAddress.Parse("");
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
