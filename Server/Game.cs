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
    }
}
