using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{

    public class Room
    {
        public string _id { get; set; }

        public Dictionary<string, Player> Users { get; }

        public string playerTurn { get; set; }

        public bool isFull { get; set; }

        public List<bool> isPlaying { get; set; }

        public Room(string id, string user)
        {
            this._id = id;

            this.Users = new Dictionary<string, Player>();
            Users.Add(user, new Player(user));

            isPlaying = new List<bool> { false, false };
            playerTurn = user;
        }

        public void AddPlayer(string playerName, Player player)
        {
            if (Users.ContainsKey(playerName))
            {
                Users[playerName] = player;
            }
            else
            {
                Users.Add(playerName, new Player(playerName));
            }

            if (Users.Count == 2)
            {
                isFull = true;
            }
        }

        public void RemovePlayer(string playerName)
        {
            if (Users.ContainsKey(playerName))
            {
                Users.Remove(playerName);
            }

            isFull = false;
        }

        public void ChangePlayerTurn(string lastTurn)
        {
            foreach (string name in Users.Keys)
            {
                if (name != lastTurn)
                {
                    playerTurn = name;
                }
            }
        }
    }
}
