using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleships
{
    public partial class loginForm : Form
    {
        bool isRegister = false;

        Timer timer;

        Network client = new Network("127.0.0.1", 2006);

        public loginForm()
        {
            InitializeComponent();
        }

        private bool isDefault(object o)
        {
            TextBox tb = (TextBox)o;

            if (tb.Text == "Username" || tb.Text == "Password" || tb.Text == "Email")
            {
                return true;
            }

            return false;
        }

        private void moveUp()
        {
            this.Height -= 2;

            int y = registerPanel.Location.Y - 2;
            Point location = new Point(registerPanel.Location.X, y);
            registerPanel.Location = location;

            y = signinPanel.Location.Y + 2;
            location = new Point(signinPanel.Location.X, y);
            signinPanel.Location = location;
        }

        private void moveDown()
        {
            this.Height += 2;

            int y = registerPanel.Location.Y + 2;
            Point location = new Point(registerPanel.Location.X, y);
            registerPanel.Location = location;

            y = signinPanel.Location.Y - 2;
            location = new Point(signinPanel.Location.X, y);
            signinPanel.Location = location;
        }

        private void createTimer()
        {
            if (timer != null)
            {
                disposeTimer();
            }

            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 1;
            timer.Start();
        }

        private void disposeTimer()
        {
            timer.Stop();
            timer.Dispose();
        }

        private void userTBox_Enter(object sender, EventArgs e)
        {
            if (isDefault(userTBox))
            {
                userTBox.Clear();
            }

            userTBox.ForeColor = Color.Turquoise;
            userPBox.Enabled = true;
            userPanel.BackColor = Color.Turquoise;
        }

        private void userTBox_Leave(object sender, EventArgs e)
        {
            userTBox.ForeColor = Color.Black;
            userPBox.Enabled = false;
            userPanel.BackColor = Color.Black;
        }

        private void passTBox_Enter(object sender, EventArgs e)
        {
            if (isDefault(passTBox))
            {
                passTBox.Clear();
            }
            
            passTBox.ForeColor = Color.Turquoise;
            passPBox.Enabled = true;
            passPanel.BackColor = Color.Turquoise;
        }

        private void passTBox_Leave(object sender, EventArgs e)
        {
            passTBox.ForeColor = Color.Black;
            passPBox.Enabled = false;
            passPanel.BackColor = Color.Black;
        }

        private void mailTBox_Enter(object sender, EventArgs e)
        {
            if (isDefault(mailTBox))
            {
                mailTBox.Clear();
            }
            
            mailTBox.ForeColor = Color.Turquoise;
            mailPBox.Enabled = true;
            mailPanel.BackColor = Color.Turquoise;
        }

        private void mailTBox_Leave(object sender, EventArgs e)
        {
            mailTBox.ForeColor = Color.Black;
            mailPBox.Enabled = false;
            mailPanel.BackColor = Color.Black;
        }

        private void signinBtn_Click(object sender, EventArgs e)
        {
            // Send user and pass to Server

            //client.SendMsg();
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            if (!isRegister)
            {
                mailTBox.Enabled = backBtn.Enabled = true;
                createTimer();
            }
            else
            {
                // Do register
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            mailTBox.Text = "Email";
            mailTBox.Enabled = backBtn.Enabled = false;
            createTimer();
        }

        private void quitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (!isRegister)
            {
                if (registerPanel.Location.Y > 350)
                {
                    moveUp();
                    backBtn.BringToFront();
                }
                else
                {
                    isRegister = true;
                    disposeTimer();
                }
            }
            else
            {
                if (this.Height < 500)
                {
                    moveDown();
                    quitBtn.BringToFront();

                }
                else
                {
                    isRegister = false;
                    disposeTimer();
                }
            }
        }
    }
}
