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
        readonly Network _Server = null;

        private bool isRunning = false;
        
        private bool isManualSetting = true;

        public mainForm()
        {
            InitializeComponent();
            _Server = new Network(this);
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            if (_Server.IP == null)
            {
                MessageBox.Show("You are not connected to the Internet!");
                return;
            }

            if (!isRunning)
            {
                isRunning = true;

                _Server.IsListening = true;

                new Thread(new ThreadStart(_Server.Run)).Start();

                UpdateLog("Listening...");

                startBtn.Enabled = false;
            }
        }

        // 
        private delegate void SafeUpdateLog(string log);

        public void UpdateLog(string log)
        {
            if (logRTBox.InvokeRequired)
            {
                var d = new SafeUpdateLog(UpdateLog);
                logRTBox.Invoke(d, new object[] { log });
            }
            else
            {
                logRTBox.Text += $" - {log}\n";
            }
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            if (isManualSetting)
            {
                _Server.IP = IPAddress.Parse("127.0.0.1");
                return;
            }

            string ip = Network.GetIPAddress(NetworkInterfaceType.Wireless80211);

            if (!string.IsNullOrEmpty(ip))
            {
                // is Wifi
                _Server.IP = IPAddress.Parse(ip);
            }
            else if (!string.IsNullOrEmpty(ip = Network.GetIPAddress(NetworkInterfaceType.Ethernet)))
            {
                // is Ethernet
                _Server.IP = IPAddress.Parse(ip);
            }
        }
    }
}
