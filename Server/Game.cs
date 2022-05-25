using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Battleships
{
    public static class Game
    {
        public static Dictionary<Player, TcpClient> currentUsers = new Dictionary<Player, TcpClient>();

        public static List<Room> rooms = new List<Room>(); 

        // Ship lengths.
        public static int[] shipLengths = new int[5] { 2, 3, 3, 4, 5 };

        public static string RandomRoomID()
        {
            Random random = new Random();
            int id = random.Next(100, 9999);

            foreach (Room room in rooms)
            {
                while (id.ToString() == room._id)
                {
                    id = random.Next(100, 9999);
                }
            }

            return id.ToString();
        }
    }
}
