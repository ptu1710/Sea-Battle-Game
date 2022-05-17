using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleships
{
    [Serializable]
    public class Ship
    {
        public int cellX;
        public int cellY;

        public int Length;

        private bool isHorizontal;

        public Ship(int x, int y, int l, bool _is)
        {
            this.cellX = x;
            this.cellY = y;

            this.Length = Game.shipLengths[l];
            this.isHorizontal = _is;
        }
    }
}
