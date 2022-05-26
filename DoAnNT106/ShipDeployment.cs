using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleships
{
    

    public partial class ShipDeployment : Form
    {
        bool isPlaySound = false;
        SoundPlayer bgSound = new SoundPlayer(Properties.Resources.bgm_track3_loop);
        private int mouseCellX = -1;
        private int mouseCellY = -1;
        private int currentShip = -1;
        private bool isHorizontal = true;
        public bool[] shipDeployed = new bool[5];

        public ShipDeployment(string ID)
        {
            InitializeComponent();
            CenterToParent();
            roomIDLabel.Text = $"ID: {ID}";
        }

        public void UpdateRoomLabel(string text)
        {
            roomIDLabel.Text = $"ID: {text}";
        }

        private void deckPictureBox_Paint(object sender, PaintEventArgs e)
        {
            GraphicContext.DrawShipSet(Game.me, e);
        }

        private void deckPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            int CoorX = GraphicContext.GetCoor(e, 0);
            int CoorY = GraphicContext.GetCoor(e, 1);

            if (currentShip != -1)
            {
                if (CoorX != -1 && CoorY != -1)
                {
                    if (GraphicContext.GetCell(CoorX) != mouseCellX || GraphicContext.GetCell(CoorY) != mouseCellY)
                    {
                        mouseCellX = GraphicContext.GetCell(CoorX);
                        mouseCellY = GraphicContext.GetCell(CoorY);

                        deckPictureBox.Refresh();

                        if (isHorizontal)
                        {
                            for (int i = 0; i < Game.shipLengths[currentShip]; i++)
                            {
                                if (mouseCellX + i <= 9 && mouseCellY <= 9)
                                {
                                    GraphicContext.DrawInnerFrameCell(mouseCellX + i, mouseCellY, currentShip, deckPictureBox);
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < Game.shipLengths[currentShip]; i++)
                            {
                                if (mouseCellY + i <= 9 && mouseCellX <= 9)
                                {
                                    GraphicContext.DrawInnerFrameCell(mouseCellX, mouseCellY + i, currentShip, deckPictureBox);
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (mouseCellX != -1 || mouseCellY != -1)
                    {
                        mouseCellX = -1;
                        mouseCellY = -1;

                        deckPictureBox.Refresh();
                    }
                }
            }
        }

        private void DeckPictureBoxClick(object sender, EventArgs e)
        {
            if (currentShip != -1 && mouseCellX != -1 && mouseCellY != -1)
            {
                if (Game.CanThereBeShip(currentShip, mouseCellX, mouseCellY, isHorizontal, Game.me.ShipSet))
                {
                    shipDeployed[currentShip] = true;

                    switch (currentShip)
                    {
                        case 0:
                            {
                                pictureBox1.Enabled = false;
                                pictureBox1.BackColor = Color.Transparent;
                                break;
                            }
                        case 1:
                            {
                                pictureBox2.Enabled = false;
                                pictureBox2.BackColor = Color.Transparent;
                                break;
                            }
                        case 2:
                            {
                                pictureBox3.Enabled = false;
                                pictureBox3.BackColor = Color.Transparent;
                                break;
                            }
                        case 3:
                            {
                                pictureBox4.Enabled = false;
                                pictureBox4.BackColor = Color.Transparent;
                                break;
                            }
                        case 4:
                            {
                                pictureBox5.Enabled = false;
                                pictureBox5.BackColor = Color.Transparent;
                                break;
                            }
                    }

                    //
                    Ship ship = new Ship(mouseCellX, mouseCellY, currentShip, isHorizontal);

                    Game.me.ShipSetImg.Add(ship);

                    Game.DeployShip(currentShip, mouseCellX, mouseCellY, isHorizontal, Game.me.ShipSet);
                    deckPictureBox.Refresh();
                    currentShip = -1;


                    bool areAllShipsDeployed = true;
                    foreach (bool isDeployed in shipDeployed)
                    {
                        if (!isDeployed)
                        {
                            areAllShipsDeployed = false;
                        }
                    }

                    if (areAllShipsDeployed)
                    {
                        playBtn.Enabled = true;
                    }
                }
            }
        }

        private void rotateBtn_Click(object sender, EventArgs e)
        {
            isHorizontal = !isHorizontal;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            currentShip = 0;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            currentShip = 1;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            currentShip = 2;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            currentShip = 3;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            currentShip = 4;
        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            if (roomIDLabel.Text.Substring(roomIDLabel.Text.LastIndexOf('-') + 1).Trim() == "")
            {
                MessageBox.Show("Your opponent is not ready.");
                return;
            }


            PlayForm myDeck = new PlayForm();
            myDeck.Text = Game.me.cName;
            myDeck.Show();

            Game._ME.SendPlayerInfo(Game.me, Game.me.roomID);


            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isPlaySound)
            {
                bgSound.Stop();
                button1.BackgroundImage = Properties.Resources.SpeakerMute;
            }
            else
            {
                bgSound.PlayLooping();
                button1.BackgroundImage = Properties.Resources.SpeakerPlay;
            }

            isPlaySound = !isPlaySound;
        }

        private void ShipDeployment_Load(object sender, EventArgs e)
        {
            isPlaySound = true;
            bgSound.PlayLooping();
            
        }
    }
}
