using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;

namespace Battleships
{
    public partial class loginForm : Form
    {
        private Timer timer;
        private ComboBox ipComboBox;
        private TextBox portTextbox;
        private Panel panel;

        private bool isRegister = false;

        string ip = "127.0.0.1";

        int port = 2006;

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
            this.Height -= 3;

            int y = registerPanel.Location.Y - 3;
            Point location = new Point(registerPanel.Location.X, y);
            registerPanel.Location = location;

            y = signinPanel.Location.Y + 3;
            location = new Point(signinPanel.Location.X, y);
            signinPanel.Location = location;
        }

        private void moveDown()
        {
            this.Height += 3;

            int y = registerPanel.Location.Y + 3;
            Point location = new Point(registerPanel.Location.X, y);
            registerPanel.Location = location;

            y = signinPanel.Location.Y - 3;
            location = new Point(signinPanel.Location.X, y);
            signinPanel.Location = location;
        }

        private Timer createTimer()
        {
            if (timer != null)
            {
                disposeTimer();
            }

            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 1;
            return timer;
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
            if (string.IsNullOrEmpty(userTBox.Text) || string.IsNullOrEmpty(passTBox.Text))
            {
                loginLabel.Text = "* Username or password cannot be null!";
                return;
            }

            // Do Sign In
            if (Game._ME == null)
            {
                Game._ME = new Network(this, ip, port);
                Game._ME.Connect();
            }
            
            Game._ME.SendMsg(0, userTBox.Text, passTBox.Text);
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            if (!isRegister)
            {
                mailTBox.Enabled = backBtn.Enabled = true;
                createTimer().Start();
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
            createTimer().Start();
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
                    orLabel.Visible = false;
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
                if (this.Height < 565)
                {
                    moveDown();
                    quitBtn.BringToFront();

                }
                else
                {
                    orLabel.Visible = true;
                    isRegister = false;
                    disposeTimer();
                }
            }
        }

        private void settingBtn_Click(object sender, EventArgs e)
        {
            if (panel == null)
            {
                panel = new Panel
                {
                    Dock = DockStyle.Fill,
                    Location = new Point(0, 0),
                    Name = "settingPanel",
                    Size = new Size(400, 500)
                };

                Label label = new Label
                {
                    AutoSize = true,
                    Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                    Location = new Point(50, 100),
                    Name = "label1",
                    Size = new Size(158, 23),
                    TabIndex = 0,
                    Text = "Server Address: "
                };

                ipComboBox = new ComboBox
                {
                    Font = new Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                    FormattingEnabled = true,
                    Location = new Point(50, 126),
                    Name = "comboBox1",
                    Size = new Size(300, 27),
                    TabIndex = 1
                };

                Label label1 = new Label
                {
                    AutoSize = true,
                    Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                    Location = new Point(50, 163),
                    Name = "label2",
                    Size = new Size(59, 23),
                    TabIndex = 2,
                    Text = "Port: "
                };

                portTextbox = new TextBox
                {
                    Font = new Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                    Location = new Point(50, 189),
                    Name = "textBox1",
                    Text = "2006",
                    Size = new Size(100, 27),
                    ReadOnly = true,
                    TabIndex = 3,
                    TextAlign = HorizontalAlignment.Center
                };

                Button button = new Button
                {
                    BackColor = Color.SpringGreen,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                    Location = new Point(150, 286),
                    Name = "button3",
                    Size = new Size(100, 50),
                    TabIndex = 5,
                    Text = "SAVE",
                    UseVisualStyleBackColor = false
                };

                button.Click += new EventHandler(saveBtn_Click);

                panel.TabIndex = 12;
                panel.Controls.Add(label);
                panel.Controls.Add(ipComboBox);
                panel.Controls.Add(label1);
                panel.Controls.Add(portTextbox);
                panel.Controls.Add(button);

                Controls.Add(panel);
                panel.BringToFront();
            }
            else
            {
                panel.Visible = true;
                panel.BringToFront();
            }
        }

        private delegate void SafeUpdateComboBox(string ip);

        private void UpdateComboBox(string ip)
        {
            if (ipComboBox.InvokeRequired)
            {
                var d = new SafeUpdateComboBox(UpdateComboBox);
                ipComboBox.Invoke(d, new object[] { ip });
            }
            else
            {
                ipComboBox.Items.Add(ip);
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            panel.SendToBack();
            panel.Visible = false;

            ip = ipComboBox.Text;
            port = int.Parse(portTextbox.Text);
        }

        private delegate void SafeUpdateForm(string msg, string cName);

        public void UpdateForm(string msg, string cName)
        {
            if (this.InvokeRequired)
            {
                var d = new SafeUpdateForm(UpdateForm);
                this.Invoke(d, new object[] { msg, cName });
            }
            else
            {
                if (msg == "success")
                {
                    this.Hide();

                    MainMenu mainMenu = new MainMenu(cName);
                    mainMenu.Location = this.Location;
                    mainMenu.Show();
                }
                else if (msg == "failed")
                {
                    loginLabel.Text = "* Username or Password is incorrect.";
                }
                else
                {
                    loginLabel.Text = "* You Are Already Logged in Elsewhere.";
                }
            }
        }

        private void loginForm_Shown(object sender, EventArgs e)
        {
            //signinBtn_Click(sender, e);
        }
    }
}
