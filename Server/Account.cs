using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    internal class Account
    {
        private string user;
        private string password;

        readonly ModifyDB modify = new ModifyDB();

        public Account()
        {
            this.user = "";
            this.password = "";
        }

        public Account(string u, string p)
        {
            this.user = u;
            this.password = p;
        }

        public string User { get => user; set => user = value; }

        public string Password { get => password; set => password = value; }

        public bool Login(string user, string pass)
        {
            string query = "SELECT * FROM Accounts WHERE TenTK='" + user + "' AND MK='" + pass + "'";

            if (modify.Accounts(query).Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Register(string user, string pass)
        {
            string isExistUserQuery = "SELECT * FROM Accounts WHERE TenTK='" + user + "'";

            if (modify.Accounts(isExistUserQuery).Count > 0)
            {
                return false;
            }

            try
            {
                string insertAccountQuery = "INSERT INTO Accounts VALUES ('" + user + "', '" + pass + "')";
                modify.RegisterAccount(insertAccountQuery);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public string ForgotPassword(string user)
        {
            string query = "SELECT * FROM Accounts WHERE TenTK='" + user + "'";

            if (modify.Accounts(query).Count > 0)
            {
                return modify.Accounts(query)[0].Password;
            }
            else
            {
                return "";
            }
        }
    }
}
