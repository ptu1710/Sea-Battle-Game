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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleships
{
    public partial class loginForm : Form
    {
        bool isRegister = false;

        System.Windows.Forms.Timer timer;

        Network client/* = new Network("127.0.0.1", 2006)*/;

        string ip = /*"172.17.15.12"*/  "127.0.0.1";

        int port = 2006;

        ComboBox ipComboBox;
        TextBox portTextbox;
        Panel panel;

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

        private System.Windows.Forms.Timer createTimer()
        {
            if (timer != null)
            {
                disposeTimer();
            }

            timer = new System.Windows.Forms.Timer();
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
            // Send user and pass to Server

            client = new Network(this, ip, port);
            client.SendMsg(0, userTBox.Text, passTBox.Text);
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
                    Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                    Location = new System.Drawing.Point(50, 100),
                    Name = "label1",
                    Size = new System.Drawing.Size(158, 23),
                    TabIndex = 0,
                    Text = "Server Address: "
                };

                ipComboBox = new ComboBox
                {
                    Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                    FormattingEnabled = true,
                    Location = new System.Drawing.Point(50, 126),
                    Name = "comboBox1",
                    Size = new System.Drawing.Size(300, 27),
                    TabIndex = 1
                };

                Label label1 = new Label
                {
                    AutoSize = true,
                    Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                    Location = new System.Drawing.Point(50, 163),
                    Name = "label2",
                    Size = new System.Drawing.Size(59, 23),
                    TabIndex = 2,
                    Text = "Port: "
                };

                portTextbox = new TextBox
                {
                    Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                    Location = new System.Drawing.Point(50, 189),
                    Name = "textBox1",
                    Text = "2006",
                    Size = new System.Drawing.Size(100, 27),
                    TabIndex = 3,
                    TextAlign = System.Windows.Forms.HorizontalAlignment.Center
                };

                Button button = new Button
                {
                    BackColor = System.Drawing.Color.Gray,
                    FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                    Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                    Location = new System.Drawing.Point(250, 179),
                    Name = "button2",
                    Size = new System.Drawing.Size(100, 37),
                    TabIndex = 4,
                    Text = "Scan",
                    UseVisualStyleBackColor = false
                };
                button.Click += new System.EventHandler(scanBtn_Click);

                Button button1 = new Button
                {
                    BackColor = System.Drawing.Color.SpringGreen,
                    FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                    Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                    Location = new System.Drawing.Point(150, 286),
                    Name = "button3",
                    Size = new System.Drawing.Size(100, 50),
                    TabIndex = 5,
                    Text = "SAVE",
                    UseVisualStyleBackColor = false
                };
                button1.Click += new System.EventHandler(saveBtn_Click);

                panel.TabIndex = 12;
                panel.Controls.Add(label);
                panel.Controls.Add(ipComboBox);
                panel.Controls.Add(label1);
                panel.Controls.Add(portTextbox);
                panel.Controls.Add(button);
                panel.Controls.Add(button1);

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

        private void scanBtn_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            ipComboBox.Items.Clear();

            string ipBase = string.IsNullOrEmpty(ipComboBox.Text) ? "172.17." : ipComboBox.Text;
            Thread scanIP = new Thread(() => scanHost(ipBase));
            scanIP.Start();
        }

        private void scanHost(string ipBase)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();

            for (int i = 1; i < 254; i++)
            {
                string ipBase1 = ipBase + i.ToString() + ".";

                for (int j = 1; j < 254; j++)
                {
                    string ip = ipBase1 + j.ToString();

                    Ping p = new Ping();

                    p.PingCompleted += new PingCompletedEventHandler(p_PingCompleted);
                    p.SendAsync(ip, 10, ip);
                }
            }

            Console.WriteLine("Done");
        }

        private void p_PingCompleted(object sender, PingCompletedEventArgs e)
        {
            string ip = e.UserState.ToString();

            if (e.Reply != null && e.Reply.Status == IPStatus.Success)
            {

                try
                {
                    string name = Dns.GetHostEntry(ip).HostName;

                    if (name.Contains(".local"))
                    {
                        name = name.Replace(".local", "");
                    }
                    Console.WriteLine($"{name}: {ip}");
                    UpdateComboBox($"{name}: {ip}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            panel.SendToBack();
            panel.Visible = false;

            string hostName = ipComboBox.Text;
            ip = hostName.Substring(hostName.LastIndexOf(": ") + 2);
            int.TryParse(portTextbox.Text, out port);
        }

        private void loginForm_Paint(object sender, PaintEventArgs e)
        {
            //Console.WriteLine("Here");
        }
    }
}
