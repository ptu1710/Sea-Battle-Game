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

        // public static Dictionary<>

        // Ship lengths.
        public static int[] shipLengths = new int[5] { 2, 3, 3, 4, 5 };
    }
}
