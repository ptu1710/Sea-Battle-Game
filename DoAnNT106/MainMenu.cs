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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            CenterToScreen();
            
        }

        public MainMenu(string cName)
        {
            InitializeComponent();
            CenterToScreen();
            usernameLabel.Text = cName;
            Network.mainMenu = this;
        }

        private void howtoBtn_Click(object sender, EventArgs e)
        {

        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            Game.me = new Player(usernameLabel.Text);

            Game._ME.SendMsg(1, Game.me.cName, roomidTBox.Text);
        }

        private void MainMenu_Shown(object sender, EventArgs e)
        {
            // playBtn_Click(sender, e);
        }

        private delegate void SafeUpdateForm(string roomID);

        public void UpdateForm(string roomID)
        {
            if (this.InvokeRequired)
            {
                var d = new SafeUpdateForm(UpdateForm);
                this.Invoke(d, new object[] { roomID });
            }
            else
            {
                ShipDeployment DeployShip = new ShipDeployment();
                DeployShip.Location = this.Location;
                DeployShip.Show();

                Hide();
            }
        }
    }
}
