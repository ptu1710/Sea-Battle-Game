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
        int avtColorCounter = 0;
        
        int mouseCellX = -1;
        int mouseCellY = -1;

        public PlayForm()
        {
            InitializeComponent();
            CenterToScreen();
            Network.playForm = this;

            meLabel.Text = Game.me.cName;
            playerLabel.Text = Game.player.cName;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!Game.me.isMyTurn)
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

                    if (mouseCellX < Game.mapSize && mouseCellY < Game.mapSize && Game.CanAttackAt(mouseCellX, mouseCellY))
                    {
                        GraphicContext.DrawScope(mouseCellX, mouseCellY, pictureBox1);
                    }
                }
            }
            else
            {
                pictureBox1.Refresh();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!Game.me.isMyTurn)
            {
                return;
            }

            if (mouseCellX < Game.mapSize && mouseCellY < Game.mapSize)
            {
                if (Game.CanAttackAt(mouseCellX, mouseCellY))
                {
                    Game._ME.SendMove(3, Game.me.roomID, Game.me.cName, mouseCellX, mouseCellY);
                    Game.me.isMyTurn = false;
                }

                pictureBox1.Refresh();
            }
        }

        public void PerformAttacked(string attackedFrom, int x, int y, bool hit)
        {
            if (attackedFrom == Game.me.cName)
            {
                Game.player.RevealedCells[x, y] = true;

                if (hit)
                {
                    Game.player.ShipSet[x, y] = 1;
                }
            }
            else
            {
                Game.me.RevealedCells[x, y] = true;

                if (hit)
                {
                    Game.me.ShipSet[x, y] = 1;
                }
            }

            UpdateDesk(pictureBox1);
            UpdateDesk(pictureBox2);
            UpdateProgress(meProgress);
            UpdateProgress(playerProgress);
        }

        private void PlayForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            GraphicContext.DrawSunkenShips(Game.me.ShipSet, Game.me.ShipLeftCells, e);

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

        private delegate void SafeUpdateDesk(PictureBox picture);

        private void UpdateDesk(PictureBox picture)
        {
            if (picture.InvokeRequired)
            {
                var d = new SafeUpdateDesk(UpdateDesk);
                picture.Invoke(d, new object[] { picture });
            }
            else
            {
                picture.Refresh();
            }
        }

        private delegate void SafeUpdateProgress(ProgressBar pg);
        private void UpdateProgress(ProgressBar pg)
        {
            if (pg.InvokeRequired)
            {
                var d = new SafeUpdateProgress(UpdateProgress);
                pg.Invoke(d, new object[] { pg });
            }
            else
            {
                pg.Value = 0;
            }
        }

        private void PlayForm_Load(object sender, EventArgs e)
        {
            meLabel.Location = new Point(mePBox.Location.X + mePBox.Width + 6, mePBox.Location.Y + 12);
            playerLabel.Location = new Point(playerPBox.Location.X - playerLabel.Width - 6, mePBox.Location.Y + 12);

            afkTimer.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            avtTimer.Start();

            if (Game.me.isMyTurn)
            {
                meProgress.Value++;

                if (meProgress.Value >= 60)
                {
                    int x = Game.RandomAttack();
                    int y = Game.RandomAttack();

                    while (!Game.CanAttackAt(x, y))
                    {
                        x = Game.RandomAttack();
                        y = Game.RandomAttack();
                    }

                    Game._ME.SendMove(3, Game.me.roomID, Game.me.cName, x, y);

                    meProgress.Value = 0;
                }
            }
            else
            {
                if (playerProgress.Value < 60)
                {
                    playerProgress.Value++;
                }
            }
        }

        private void avtTimer_Tick(object sender, EventArgs e)
        {
            if (avtColorCounter < 7)
            {
                avtColorCounter++;
            }
            else
            {
                avtColorCounter = 0;
            }

            if (Game.me.isMyTurn)
            {
                mePBox1.BackColor = GraphicContext.colors[avtColorCounter];
            }
            else
            {
                playerPBox1.BackColor = GraphicContext.colors[avtColorCounter];
            }    
        }
    }
}
