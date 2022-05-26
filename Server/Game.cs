using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Battleships
{
    public static class Game
    {
        public static Dictionary<string, TcpClient> currentTCPs = new Dictionary<string, TcpClient>();
        
        public static Dictionary<string, Player> currentUsers = new Dictionary<string, Player>();

        public static Dictionary<string, Room> rooms = new Dictionary<string, Room>(); 

        // Ship lengths.
        public static int[] shipLengths = new int[5] { 2, 3, 3, 4, 5 };

        public static string RandomRoomID()
        {
            Random random = new Random();
            int id = random.Next(100, 9999);

            foreach (string roomid in rooms.Keys)
            {
                while (id.ToString() == roomid)
                {
                    id = random.Next(100, 9999);
                }
            }

            return id.ToString();
        }

        public static int PerformAttack(int cellX, int cellY, string roomID, string attackName)
        {
            Player attackedPlayer = GetPlayer(roomID, attackName);

            if (attackedPlayer == null)
            {
                return -1;
            }

            // Mark the cell as revealed.
            attackedPlayer.RevealedCells[cellX, cellY] = true;

            // Is the attack a hit?
            if (attackedPlayer.ShipSet[cellX, cellY] != -1)
            {
                // Decrease the amount of cells left for the ship that has been hit.
                attackedPlayer.ShipLeftCells[attackedPlayer.ShipSet[cellX, cellY]]--;

                if (attackedPlayer.ShipLeftCells[attackedPlayer.ShipSet[cellX, cellY]] == 0)
                {
                    // The ship was completely shot down.
                    attackedPlayer.ShipsLeft--;
                }

                return attackedPlayer.ShipSet[cellX, cellY];
            }
            else
            {
                return -1;
            }
        }

        public static bool IsEndGame(string roomID, string attackName)
        {
            Player attackedPlayer = GetPlayer(roomID, attackName);

            if (attackedPlayer == null)
            {
                return false;
            }

            // Is the game over?
            if (attackedPlayer.ShipsLeft == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static Player GetPlayer(string roomID, string not_User)
        {
            Player is_User = null;

            foreach (string playerName in rooms[roomID].Users.Keys)
            {
                if (playerName != not_User)
                {
                    is_User = rooms[roomID].Users[playerName];
                }
            }

            return is_User;
        }
    }
}
