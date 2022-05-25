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

        private void mainForm_Shown(object sender, EventArgs e)
        {
            startBtn_Click(sender, e);
        }

        public static bool PerformAttack(int cellX, int cellY, string attackedName)
        {
            Player attackedPlayer = null;

            foreach (Player player in Game.currentUsers.Keys)
            {
                if (player.name != attackedName)
                {
                    attackedPlayer = player;
                }
            }

            if (attackedPlayer == null)
            {
                return false;
            }

            // Mark the cell as revealed.
            attackedPlayer.RevealedCells[cellX, cellY] = true;

            // Is the attack a hit?
            if (attackedPlayer.ShipSet[cellX, cellY] != -1)
            {
                // Decrease the amount of cells left for the ship that has been hit.
                attackedPlayer.ShipLeftCells[attackedPlayer.ShipSet[cellX, cellY]]--;

                if (attackedPlayer.ShipLeftCells[attackedPlayer.ShipSet[cellX, cellY]] == 0)
                {
                    // The ship was completely shot down.
                    attackedPlayer.ShipsLeft--;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsEndGame(string attackedName)
        {
            Player attackedPlayer = null;

            foreach (Player player in Game.currentUsers.Keys)
            {
                if (player.name != attackedName)
                {
                    attackedPlayer = player;
                }
            }

            if (attackedPlayer == null)
            {
                return true;
            }

            // Is the game over?
            if (attackedPlayer.ShipsLeft == 0)
            {
                return true;
            }
            else
            {
                return false;
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
