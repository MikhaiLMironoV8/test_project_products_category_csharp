using MySql.Data.MySqlClient;

namespace test_project_products_category_csharp.DatabaseConnection
{
    public class ConnectionDB
    {
        static readonly string server = "127.0.0.1";
        static readonly string port = "3306";
        static readonly string database = "test_project_product_category_csharp";
        static readonly string username = "root";
        static readonly string password = "";
        public static readonly MySqlConnection Connection = new MySqlConnection($"server={server}; port={port}; database={database}; username={username}; password={password}");
    }
}
