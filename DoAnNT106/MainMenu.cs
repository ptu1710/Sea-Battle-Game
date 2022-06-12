using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleships
{
    public partial class MainMenu : Form
    {
        bool isPlayingSound = false;

        SoundPlayer bgSound = new SoundPlayer(Properties.Resources.bgm_track1_loop);

        public MainMenu(string cName)
        {
            InitializeComponent();
            CenterToScreen();

            usernameLabel.Text = cName;
            Game.me = new Player(cName);
            Network.mainMenu = this;
        }

        private void howtoBtn_Click(object sender, EventArgs e)
        {
            TutorialForm frm = new TutorialForm();
            frm.ShowDialog();
        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            Game._ME.SendMsg(1, Game.me.cName, roomidTBox.Text);
        }

        private delegate void SafeUpdateForm(int code, string roomID, string otherUser);

        public void UpdateForm(int code, string roomID, string otherUser)
        {
            if (this.InvokeRequired)
            {
                var d = new SafeUpdateForm(UpdateForm);
                this.Invoke(d, new object[] { code, roomID, otherUser });
            }
            else
            {
                if (code == 5)
                {
                    usernameLabel.Text = usernameLabel.Text.Replace(otherUser, "");
                    return;
                }

                if (usernameLabel.Text.Contains(Game.me.cName))
                {
                    usernameLabel.Text = $"{roomID} - {otherUser}";
                }
                else if (usernameLabel.Text.Contains(" - ") && otherUser != Game.me.cName)
                {
                    usernameLabel.Text += $"{otherUser}";
                }

                if (Network.DeployShip != null && !Network.DeployShip.IsDisposed)
                {
                    Network.DeployShip.UpdateRoomLabel(usernameLabel.Text);
                }
                else
                {
                    Network.DeployShip = new ShipDeployment(usernameLabel.Text);
                }

                Network.DeployShip.Show();

                Hide();
            }
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            button1_Click(sender, e);

            this.CenterToParent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isPlayingSound)
            {
                bgSound.Stop();
                button1.BackgroundImage = Properties.Resources.SpeakerMute;
            }
            else
            {
                bgSound.PlayLooping();
                button1.BackgroundImage= Properties.Resources.SpeakerPlay;
            }

            isPlayingSound = !isPlayingSound;
        }

        public void BackFromDeployFrom(string cName)
        {
            Game.me = null;
            Game.me = new Player(cName);

            usernameLabel.Text = cName;
            bgSound.PlayLooping();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you want to log out?", "LOGOUT?", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
            {
                bgSound.Stop();
                bgSound.Dispose();
                bgSound = null;

                Game._ME.SendMsg(0, Game.me.cName, "");
                Network.loginForm.Show();

                this.Dispose();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
