using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DB_YTB_TUTO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DatabaseConnection connection = new DatabaseConnection("localhost", "db_ytb", "root", "");
            DatabaseRequest request = new DatabaseRequest(connection);

            Products_Request productsRequest = new Products_Request(request);

            productsRequest.InsertProduct("Rolex", 9999);
            Thread.Sleep(1000);
            productsRequest.InsertProduct("Tissot", 9999);
            Thread.Sleep(1000);
            productsRequest.UpdateProduct(12,"Grovana", 200);
            Thread.Sleep(1000);
            productsRequest.DeleteProduct(12);
            Thread.Sleep(1000);
            List<string> products = productsRequest.GetProducts();
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
            Console.ReadKey();
        }
    }
}
