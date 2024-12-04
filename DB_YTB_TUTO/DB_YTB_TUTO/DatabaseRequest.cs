using System;
using System.Collections.Generic;
using System.Data;

namespace DB_YTB_TUTO
{
    internal class DatabaseRequest
    {
        private DatabaseConnection dbconnection;

        public DatabaseRequest(DatabaseConnection connection)
        {
            dbconnection = connection;
        }

        // Read (Get data from the database)
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
                            result.Add(reader[2].ToString()); // Adaptez le numéro de colonne si nécessaire
                        }
                    }
                }
            }
            return result;
        }

        // Create (Insert data into the database)
        public bool InsertData(string query, Dictionary<string, object> parameters)
        {
            using (var connection = dbconnection.GetConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;

                    // Add parameters to the query
                    foreach (var param in parameters)
                    {
                        var dbParam = command.CreateParameter();
                        dbParam.ParameterName = param.Key;
                        dbParam.Value = param.Value;
                        command.Parameters.Add(dbParam);
                    }

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        // Update (Modify data in the database)
        public bool UpdateData(string query, Dictionary<string, object> parameters)
        {
            using (var connection = dbconnection.GetConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;

                    // Add parameters to the query
                    foreach (var param in parameters)
                    {
                        var dbParam = command.CreateParameter();
                        dbParam.ParameterName = param.Key;
                        dbParam.Value = param.Value;
                        command.Parameters.Add(dbParam);
                    }

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        // Delete (Remove data from the database)
        public bool DeleteData(string query, Dictionary<string, object> parameters)
        {
            using (var connection = dbconnection.GetConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;

                    // Add parameters to the query
                    foreach (var param in parameters)
                    {
                        var dbParam = command.CreateParameter();
                        dbParam.ParameterName = param.Key;
                        dbParam.Value = param.Value;
                        command.Parameters.Add(dbParam);
                    }

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
