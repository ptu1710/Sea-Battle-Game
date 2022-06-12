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

        private delegate void SafeUpdateForm(string roomID, string otherUser);

        public void UpdateForm(string roomID, string otherUser)
        {
            if (this.InvokeRequired)
            {
                var d = new SafeUpdateForm(UpdateForm);
                this.Invoke(d, new object[] { roomID, otherUser });
            }
            else
            {
                if (usernameLabel.Text.Contains(Game.me.cName))
                {
                    usernameLabel.Text = $"{roomID} - {otherUser}";
                }
                else if (usernameLabel.Text.Contains(" - ") && otherUser != "")
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

        public void BackFromDeployFrom()
        {
            usernameLabel.Text = Game.me.cName;
            bgSound.PlayLooping();
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            bgSound.Stop();
            bgSound.Dispose();
            bgSound = null;

            Game._ME.SendMsg(0, Game.me.cName, "");
            Network.loginForm.Show();

            this.Close();
            this.Dispose();
        }
    }
}
