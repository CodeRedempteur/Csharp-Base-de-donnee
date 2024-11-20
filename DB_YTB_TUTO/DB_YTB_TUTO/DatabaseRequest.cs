using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_YTB_TUTO
{
    internal class DatabaseRequest
    {
        private DatabaseConnection dbconnection;
        public DatabaseRequest(DatabaseConnection connection)
        {
            dbconnection = connection;
        }

        public List<string> GetData(string query)
        {
            List<string> result = new List<string>();

            using (var connection = dbconnection.GetConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(reader[2].ToString());
                        }
                        return result;
                    }
                }
            }
        }
    }
}
