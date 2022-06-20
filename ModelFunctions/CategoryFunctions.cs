using System.Data;
using test_project_products_category_csharp.Models;
using MySql.Data.MySqlClient;
using test_project_products_category_csharp.DatabaseConnection;

namespace test_project_products_category_csharp.ModelFunctions
{
    public class CategoryFunctions
    {
        public static List<Category> GetCategoryUsing()
        {
            if (ConnectionDB.Connection.State == ConnectionState.Closed)
            {
                ConnectionDB.Connection.Open();
            }
            MySqlCommand command = new MySqlCommand("SELECT `categories`.`name`" +
                                                    "FROM `products`" +
                                                    "INNER JOIN `categories` ON `categories`.`id` = `products`.`category_id`" +
                                                    "GROUP BY `categories`.`name`" +
                                                    "ORDER BY `categories`.`name`", ConnectionDB.Connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<Category> categories = new List<Category>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    Category category = new Category();
                    category.CategoryName = reader.GetString(0);
                    categories.Add(category);
                }
                reader.Close();
            }
            if (ConnectionDB.Connection.State == ConnectionState.Open)
            {
                ConnectionDB.Connection.Close();
            }
            return categories;
        }
    }
}
