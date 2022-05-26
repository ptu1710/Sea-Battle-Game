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
                    if (shipSet[cellX, cellY] != -1)
                    {
                        // Invalid layout found.
                        return false;
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
                    if (shipSet[cellX, cellY] != -1)
                    {
                        // Invalid layout found.
                        return false;
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

        public static bool CanAttackAt(int x, int y)
        {
            return !(player.RevealedCells[x, y]);
        }

        public static int RandomAttack()
        {
            Random random = new Random();
            return random.Next(0, 9);
        }

        public static void PerformWin(string wonUser)
        {
            
        }
    }
}
