using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleships
{
    public partial class PlayForm : Form
    {
        int mouseCellX = -1;
        int mouseCellY = -1;

        public PlayForm()
        {
            InitializeComponent();
            CenterToScreen();
            Network.playForm = this;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!Game.isMyTurn)
            {
                return;
            }

            int CoorX = GraphicContext.GetCoor(e, 0);
            int CoorY = GraphicContext.GetCoor(e, 1);

            if (CoorX != -1 && CoorY != -1)
            {
                if (GraphicContext.GetCell(CoorX) != mouseCellX || GraphicContext.GetCell(CoorY) != mouseCellY)
                {
                    mouseCellX = GraphicContext.GetCell(CoorX);
                    mouseCellY = GraphicContext.GetCell(CoorY);

                    pictureBox1.Refresh();

                    if (mouseCellX < Game.mapSize && mouseCellY < Game.mapSize)
                    {
                        GraphicContext.DrawInnerFrameCell(mouseCellX, mouseCellY, pictureBox1);
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (Game.isMyTurn)
            {
                if (mouseCellX < Game.mapSize && mouseCellY < Game.mapSize)
                {
                    // Note
                    if (Game.player == null)
                    {
                        Game.player = new Player("");
                    }

                    // Random random = new Random();
                    // int hit = random.Next(0, 1);
                    // PerformAttacked(mouseCellX, mouseCellY, true);

                    Game.isMyTurn = false;
                    Game._ME.SendMove(3, Game.me.roomID, Game.me.cName, mouseCellX, mouseCellY);

                    pictureBox1.Refresh();
                }
            }
            else
            {
                // Game.isMyTurn = true;
                MessageBox.Show($"Not your turn!", $"{Game.me.cName}", MessageBoxButtons.OK);
            }
        }

        public void PerformAttacked(string user, int x, int y, bool hit)
        {
            /*Game.me.RevealedCells[x, y] = true;
            Game.player.RevealedCells[x, y] = true;

            if (hit)
            {
                Game.me.ShipSet[x, y] = 1;
                Game.player.ShipSet[x, y] = 1;
            }*/

            MessageBox.Show(user);

            pictureBox1.Refresh();
            pictureBox2.Refresh();

            // Game.isMyTurn = true;
        }

        private void PlayForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (Game.player != null)
            {
                GraphicContext.DrawDeckStatus(Game.player.RevealedCells, Game.player.ShipSet, e);
            }
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            GraphicContext.DrawShipSet(Game.me, e);

            GraphicContext.DrawDeckStatus(Game.me.RevealedCells, Game.me.ShipSet, e);
        }
    }
}
