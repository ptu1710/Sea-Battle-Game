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

        public List<Player> Users { get; set; }

        public string isPlayer1Turn { get; set; }

        public bool isPlaying { get; set; }

        public Room(string id, List<Player> user)
        {
            this._id = id;
            this.Users = user;
            isPlaying = false;
            isPlayer1Turn = Users[0].cName;
        }
    }
}
