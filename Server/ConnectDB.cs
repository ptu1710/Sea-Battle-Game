using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Battleships
{
    class ConnectDB
    {
        private static readonly string DatabaseDir = Environment.CurrentDirectory.Replace("bin\\Debug", "AccountDB.mdf");

        // Trong trường hợp bị lỗi không thể đăng nhập khi chạy thử,
        // hãy đưa đường dẫn hiện tại của file "AccountDB.mdf" trong folder Server vào phần "AttachDbFilename="
        private static string connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={DatabaseDir};Integrated Security=True";
        //private static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ADMIN\Source\Repos\DoAnNT106\Server\AccountDB.mdf;Integrated Security=True";
        
        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
