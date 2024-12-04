using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_YTB_TUTO
{
    internal class Products_Request
    {
        private DatabaseRequest dbrequest;
        public Products_Request(DatabaseRequest request)
        {
            dbrequest = request;
        }

        public List<string> GetProducts()
        {
            return dbrequest.GetData("SELECT * FROM t_product");
        }


        public void InsertProduct(string name, int price)
        {
            dbrequest.InsertData("INSERT INTO t_product (Product_Name, Product_price) VALUES (@name, @price)", new Dictionary<string, object> { { "@name", name }, { "@price", price } });
        }


        public void UpdateProduct(int id, string name, int price)
        {
            dbrequest.UpdateData("UPDATE t_product SET Product_Name = @name, Product_price = @price WHERE ID_Product = @id", new Dictionary<string, object> { { "@id", id }, { "@name", name }, { "@price", price } });
        }
        public void DeleteProduct(int id) {
        dbrequest.DeleteData("DELETE FROM t_product WHERE ID_Product = @id", new Dictionary<string, object> { { "@id", id } });
        }
    }
}
