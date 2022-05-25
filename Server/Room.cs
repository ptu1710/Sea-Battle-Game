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

        public Room(string id, List<string> user)
        {
            this._id = id;
            this.users = user;
        }

        public List<string> users { get; set; }
        public string HanhDong { get; set; }
        public string luotDanhCo { get; set; }
        public string luotThaiXN { get; set; }
        public int XiNgau { get; set; }
        public List<string> DsUserSS { get; set; }
        public bool status { get; set; }
        public string[] QuanLyBanCo { get; set; }
        public string[] QuanLyChuong { get; set; }
        
    }
}
