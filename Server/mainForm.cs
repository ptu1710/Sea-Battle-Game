using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class mainForm : Form
    {
        ModifyDB modify = new ModifyDB();

        public mainForm()
        {
            InitializeComponent();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            _iPAddress = IPAddress.Parse(ipTBox.Text);
            if (isRunning)
            {
                isRunning = false;

                logListView.Items.Add("Stop listening!");
                startBtn.Text = "START";

                tcpListener.Stop();

                listenThread.Abort();
                listenThread = null;
            }
            else
            {
                isRunning = true;
                
                listenThread = new Thread(Listen);
                listenThread.Start();

                logListView.Items.Add("Start listening...");
                startBtn.Text = "STOP";
            }
        }
    }
}
