using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_YTB_TUTO
{
    internal class Program
    {
        static void Main(string[] args)
        {


            DatabaseConnection connection = new DatabaseConnection("localhost", "db_ytb", "Wow", "");
            DatabaseRequest request = new DatabaseRequest(connection);
            List<string> result = request.GetData("SELECT * FROM t_product");
            foreach (string item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
