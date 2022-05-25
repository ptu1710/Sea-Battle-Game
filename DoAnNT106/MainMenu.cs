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
        }

        private void howtoBtn_Click(object sender, EventArgs e)
        {

        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            Game.Initialize();
            Game.me = new Player(usernameLabel.Text);

            ShipDeployment DeployShip = new ShipDeployment();
            DeployShip.Location = this.Location;
            DeployShip.Show();

            Hide();
        }

        private void MainMenu_Shown(object sender, EventArgs e)
        {
            // playBtn_Click(sender, e);
        }
    }
}
