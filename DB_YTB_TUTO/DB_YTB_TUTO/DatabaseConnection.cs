using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_YTB_TUTO
{
    internal class DatabaseConnection
    {
        private string connectionString;
        public DatabaseConnection(string server, string database, string user,string password)
        {
          connectionString = $"Server={server};Database={database};User Id={user};Password={password};";
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
