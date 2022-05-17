using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battleships
{
    public static class Game
    {
        // Ship lengths.
        public static int[] shipLengths = new int[5] { 2, 3, 3, 4, 5 };

        // [true] player1's move / [false] player2's move.
        public static bool isMyTurn;

        // Player information.
        public static Player me;

        public static Player player;

        public static int mapSize = 10;

        public static Network _ME;

        // Inicalize the game.
        static public void Initialize()
        {
            isMyTurn = true;
        }

        // Method returns whether a cell can contain a ship.
        // First implementation is dedicated for the ship deployment.
        static public bool CanThereBeShip(int currentShip, int cellX, int cellY, bool isHorizontal, int[,] shipSet)
        {
            // Is the index of the most upper-left cell within the bounds.
            if (cellX < 0 || cellY < 0)
            {
                return false;
            }

            if (isHorizontal)
            {
                if (cellX + shipLengths[currentShip] - 1 < mapSize)
                {
                    // Searching for an invalid layout on the grid.
                    for (int i = Math.Max(0, cellX - 1); i <= Math.Min(mapSize, cellX + shipLengths[currentShip]); i++)
                    {
                        for (int j = Math.Max(0, cellY - 1); j <= Math.Min(mapSize, cellY + 1); j++)
                        {
                            if (shipSet[i, j] != -1)
                            {
                                // Invalid layout found.
                                return false;
                            }
                        }
                    }

                    // Invalid layout not found.
                    return true;
                }
                else
                {
                    // Out of the bounds of the grid.
                    return false;
                }
            }
            else
            {
                // Vertical validation.
                if (cellY + shipLengths[currentShip] - 1 < mapSize)
                {
                    // Searching for an invalid layout on the grid.
                    for (int i = Math.Max(0, cellX - 1); i <= Math.Min(mapSize, cellX + 1); i++)
                    {
                        for (int j = Math.Max(0, cellY - 1); j <= Math.Min(mapSize, cellY + shipLengths[currentShip]); j++)
                        {
                            if (shipSet[i, j] != -1)
                            {
                                // Invalid layout found.
                                return false;
                            }
                        }
                    }

                    // Invalid layout not found.
                    return true;
                }
                else
                {
                    // Out of the bounds of the grid.
                    return false;
                }
            }
        }

        // Deploy a ship into a ship set.
        static public void DeployShip(int currentShip, int cellX, int cellY, bool isHorizontal, int[,] shipSet)
        {
            if (isHorizontal)
            {
                for (int i = 0; i < shipLengths[currentShip]; i++)
                {
                    shipSet[cellX + i, cellY] = currentShip;
                }
            }
            else
            {
                for (int i = 0; i < shipLengths[currentShip]; i++)
                {
                    shipSet[cellX, cellY + i] = currentShip;
                }
            }
        }

        // Adds probability to all the spots the ship can be deployed.
        static private void probabilitySetAddShip(int currentShip, int cellX, int cellY, bool isHorizontal, int[,] probabilitySet)
        {
            for (int i = 0; i < shipLengths[currentShip]; i++)
            {
                if (isHorizontal)
                {
                    probabilitySet[cellX + i, cellY]++;
                }
                else
                {
                    probabilitySet[cellX, cellY + i]++;
                }
            }
        }

        // Perform an attack of a player on a player at a given cell.
        // [true] if game is over and the attacker won / [false] if not.
        static public bool PerformAttack(int cellX, int cellY, Player attacker, Player attacked)
        {

            // Mark the cell as revealed.
            attacked.RevealedCells[cellX, cellY] = true;


            // Mark the lastly revealed cell.
            attacked.LastRevealedCells[0] = cellX;
            attacked.LastRevealedCells[1] = cellY;

            // Is the attack a hit?
            if (attacked.ShipSet[cellX, cellY] != -1)
            {
                // Decrease the amount of cells left for the ship that has been hit.
                attacked.ShipLeftCells[attacked.ShipSet[cellX, cellY]]--;

                if (attacked.ShipLeftCells[attacked.ShipSet[cellX, cellY]] == 0)
                {
                    // The ship was completely shot down.
                    attacked.ShipsLeft--;

                    // How many neighbouring cells has been revealed with the sunken ship.
                    int extraRevealedCells = 0;

                    // Reveal neighbouring cells of the sunken ship.
                    for (int x = 0; x < mapSize; x++)
                    {
                        for (int y = 0; y < mapSize; y++)
                        {
                            if (attacked.ShipSet[x, y] == attacked.ShipSet[cellX, cellY])
                            {
                                try
                                {
                                    if (!attacked.RevealedCells[x - 1, y - 1])
                                    {
                                        attacked.RevealedCells[x - 1, y - 1] = true;
                                        extraRevealedCells++;
                                    }
                                }
                                catch { };

                                try
                                {
                                    if (!attacked.RevealedCells[x - 1, y])
                                    {
                                        attacked.RevealedCells[x - 1, y] = true;
                                        extraRevealedCells++;
                                    }
                                }
                                catch { };

                                try
                                {
                                    if (!attacked.RevealedCells[x - 1, y + 1])
                                    {
                                        attacked.RevealedCells[x - 1, y + 1] = true;
                                        extraRevealedCells++;
                                    }
                                }
                                catch { };

                                try
                                {
                                    if (!attacked.RevealedCells[x, y - 1])
                                    {
                                        attacked.RevealedCells[x, y - 1] = true;
                                        extraRevealedCells++;
                                    }
                                }
                                catch { };

                                try
                                {
                                    if (!attacked.RevealedCells[x, y + 1])
                                    {
                                        attacked.RevealedCells[x, y + 1] = true;
                                        extraRevealedCells++;
                                    }
                                }
                                catch { };

                                try
                                {
                                    if (!attacked.RevealedCells[x + 1, y - 1])
                                    {
                                        attacked.RevealedCells[x + 1, y - 1] = true;
                                        extraRevealedCells++;
                                    }
                                }
                                catch { };

                                try
                                {
                                    if (!attacked.RevealedCells[x + 1, y])
                                    {
                                        attacked.RevealedCells[x + 1, y] = true;
                                        extraRevealedCells++;
                                    }
                                }
                                catch { };

                                try
                                {
                                    if (!attacked.RevealedCells[x + 1, y + 1])
                                    {
                                        attacked.RevealedCells[x + 1, y + 1] = true;
                                        extraRevealedCells++;
                                    }
                                }
                                catch { };
                            }
                        }
                    }

                    // Is the game over?
                    if (attacked.ShipsLeft == 0)
                    {
                        return true;
                    }
                    else
                    {
                        // Else return a false, some ships are left
                        return false;
                    }
                }
                else
                {
                    //There are some ship cells left in this ship, so that Game dont end
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
    }
}
