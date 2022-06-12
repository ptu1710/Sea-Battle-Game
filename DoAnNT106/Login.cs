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

        readonly int port = 2006;

        public loginForm()
        {
            InitializeComponent();
            this.Text = "LOGIN?";
        }

        private bool isDefault(object o)
        {
            TextBox tb = (TextBox)o;

            if (tb.Text == "Username" || tb.Text == "Password")
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

            signinBtn.Enabled = false;
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

            signinBtn.Enabled = true;
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
            if (string.IsNullOrEmpty(userTBox.Text))
            {
                userTBox.Text = "Username";
            }

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
            if (string.IsNullOrEmpty(passTBox.Text))
            {
                passTBox.Text = "Password";
            }

            passTBox.ForeColor = Color.Black;
            passPBox.Enabled = false;
            passPanel.BackColor = Color.Black;
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
                Game._ME = new Network(ip, port);
                Network.loginForm = this;
            }

            if (Game._ME.Connect())
            {
                Game._ME.SendMsg(0, userTBox.Text, passTBox.Text);
            }
            else
            {
                UpdateForm("timeout", "");
            }
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            if (!isRegister)
            {
                this.Text = "REGISTER?";
                userTBox.Clear();
                passTBox.Clear();
                backBtn.Enabled = true;
                createTimer().Start();
            }
            else
            {
                if (string.IsNullOrEmpty(userTBox.Text) || string.IsNullOrEmpty(passTBox.Text))
                {
                    loginLabel.Text = "* Username or password cannot be null!";
                    return;
                }

                // Do register
                if (Game._ME == null)
                {
                    Game._ME = new Network(ip, port);
                    Network.loginForm = this;
                }

                if (Game._ME.Connect())
                {
                    Game._ME.SendMsg(0, userTBox.Text, passTBox.Text, "1");
                }
                else
                {
                    UpdateForm("timeout", "");
                }
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(userTBox.Text))
            {
                userTBox.Text = "Username";
            }

            if (string.IsNullOrEmpty(passTBox.Text))
            {
                passTBox.Text = "Password";
            }

            backBtn.Enabled = false;
            createTimer().Start();
        }

        private void quitBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
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
                    Name = "ipTBox",
                    Size = new Size(158, 23),
                    TabIndex = 0,
                    Text = "Server Address: "
                };

                ipComboBox = new ComboBox
                {
                    Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                    FormattingEnabled = true,
                    Location = new Point(50, 126),
                    Name = "ipComboBox",
                    Text = "127.0.0.1",
                    Size = new Size(300, 27),
                    TabIndex = 1,
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
                    Name = "portTBox",
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
                    Name = "saveBtn",
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

            ip = string.IsNullOrEmpty(ipComboBox.Text) ? "127.0.0.1" : ipComboBox.Text;
        }

        private delegate void SafeUpdateForm(string msg, string cName, string option = "");

        public void UpdateForm(string msg, string cName, string option = "")
        {
            if (this.InvokeRequired)
            {
                var d = new SafeUpdateForm(UpdateForm);
                this.Invoke(d, new object[] { msg, cName, option });
            }
            else
            {
                if (msg == "timeout")
                {
                    loginLabel.Text = "* The network connection timed out.";
                }
                else if (msg == "success")
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
                else if (msg == "pass")
                {
                    loginLabel.Text = $"* Account already exists, your password is {option}.";
                }
                else if (msg == "created")
                {
                    loginLabel.Text = $"* Account created successfully!";
                    DialogResult result = MessageBox.Show("Account Created!", $"Your username is {cName}, password is {option}");

                    if (result == DialogResult.OK)
                    {
                        backBtn.Enabled = false;
                        createTimer().Start();
                    }
                }
                else
                {
                    loginLabel.Text = "* You are already logged in elsewhere.";
                }
            }
        }
    }
}
