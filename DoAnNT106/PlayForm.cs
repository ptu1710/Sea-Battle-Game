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
    public partial class PlayForm : Form
    {
        static bool isMyTurn = true;

        int mouseCellX = -1;
        int mouseCellY = -1;

        public PlayForm()
        {
            InitializeComponent();
            CenterToScreen();
        }

        public PlayForm(PictureBox pic)
        {
            InitializeComponent();
            CenterToScreen();
            panel2.Controls.Add(pic);
            pic.Location = new Point(0,0);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            int CoorX = GraphicContext.GetCoor(e, 0);
            int CoorY = GraphicContext.GetCoor(e, 1);

            if (isMyTurn)
            {
                if (CoorX != -1 && CoorY != -1)
                {
                    if (GraphicContext.GetCell(CoorX) != mouseCellX || GraphicContext.GetCell(CoorY) != mouseCellY)
                    {
                        mouseCellX = GraphicContext.GetCell(CoorX);
                        mouseCellY = GraphicContext.GetCell(CoorY);

                        pictureBox1.Refresh();

                        GraphicContext.DrawScope(mouseCellX, mouseCellY, pictureBox1);

                    }
                }
            }
        }
    }
}
