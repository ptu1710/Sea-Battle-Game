using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battleships
{
    public class Player
    {
        public string name;

        // Locations of the players' ships.
        public int[,] ShipSet { get; set; }

        // Revealed cells
        public bool[,] RevealedCells { get; set; }

        // Last revealed cells.
        public int[] LastRevealedCells { get; set; }

        // Ships cells left.
        public int[] ShipLeftCells { get; set; }

        // Ships left count.
        public int ShipsLeft { get; set; }

        public Player(string name)
        {
            this.name = name;

            ShipLeftCells = new int[] { 2, 3, 3, 4, 5 };
            ShipsLeft = 5;
            ShipSet = new int [10, 10];
            RevealedCells = new bool[10, 10];

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    RevealedCells[i, j] = false;
                }
            }
        }

        public void setShipSet(int[,] shipSet)
        {
            this.ShipSet = shipSet;
        }
    }
}
