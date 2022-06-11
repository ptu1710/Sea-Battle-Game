using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Battleships
{
    internal class ModifyDB
    {
        SqlCommand sqlCommand;

        SqlDataReader reader;

        public ModifyDB()
        {

        }

        public List<Account> Accounts(string query)
        {
            List<Account> accounts = new List<Account>(); 

            using (SqlConnection sqlConnection = ConnectDB.GetSqlConnection())
            {
                sqlConnection.Open();

                sqlCommand =  new SqlCommand(query, sqlConnection);
                reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    accounts.Add(new Account(reader.GetString(0), reader.GetString(1)));
                }

                sqlConnection.Close();
            }

            return accounts;
        }

        public void RegisterAccount(string query)
        {
            using (SqlConnection sqlConnection = ConnectDB.GetSqlConnection())
            {
                sqlConnection.Open();

                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }

        public string getPassword(string username)
        {
            string pass = "";

            string query = "SELECT * FROM Accounts WHERE TenTK='" + username + "'";

            using (SqlConnection sqlConnection = ConnectDB.GetSqlConnection())
            {
                sqlConnection.Open();

                sqlCommand = new SqlCommand(query, sqlConnection);
                reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.GetValue(0).ToString() == username)
                    {
                        pass = reader.GetValue(1).ToString();
                    }
                }

                sqlConnection.Close();
            }

            return pass;
        }
    }
}
