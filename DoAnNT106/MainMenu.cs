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

        public MainMenu(string name)
        {
            InitializeComponent();
            CenterToScreen();
            usernameLabel.Text = name;
        }

        private void howtoBtn_Click(object sender, EventArgs e)
        {

        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            Game.Initialize();

            Game.player1 = new Player();
            Game.player2 = new Player();

            ShipDeployment DeployShip = new ShipDeployment();
            DeployShip.Location = this.Location;
            DeployShip.Show();

            Hide();
        }
    }
}
