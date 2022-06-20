using System.Data;
using test_project_products_category_csharp.Models;
using MySql.Data.MySqlClient;
using test_project_products_category_csharp.DatabaseConnection;

namespace test_project_products_category_csharp.ModelFunctions
{
    public class ProductFunctions
    {
        public static List<Product> GetProductsCategory()
        {
            if(ConnectionDB.Connection.State == ConnectionState.Closed)
            {
                ConnectionDB.Connection.Open();
            }
            MySqlCommand command = new MySqlCommand("SELECT `products`.`name`, `categories`.`name`" +
                                                    "FROM `products`" +
                                                    "INNER JOIN `categories` ON `categories`.`id` = `products`.`category_id`", ConnectionDB.Connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<Product> products = new List<Product>();
            if(reader != null)
            {
                while(reader.Read())
                {
                    Product product = new Product();
                    product.ProductName = reader.GetString(0);
                    product.CategoryName = reader.GetString(1);
                    products.Add(product);
                }
                reader.Close();
            }
            if(ConnectionDB.Connection.State == ConnectionState.Open)
            {
                ConnectionDB.Connection.Close();
            }
            return products;
        }
    }
}
