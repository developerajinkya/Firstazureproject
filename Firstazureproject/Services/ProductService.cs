using System.Data;
using System.Data.SqlClient;
using Firstazureproject.Models;


namespace Firstazureproject.Services
{
    public class ProductService
    {
        private static String db_source = "az-trail.database.windows.net";
        private static String db_user = "Ajinkya_az";
        private static String db_password = "Pass@860509";
        private static String db_database = "Firstazure";

        private SqlConnection GetConnection()
        {
            var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID = db_user;
            _builder.Password = db_password;
            _builder.InitialCatalog = db_database;
            return new SqlConnection(_builder.ConnectionString);
        }
        public List<Product> GetProducts()
        {
            SqlConnection conn = GetConnection();

            List<Product> _product_lst = new List<Product>();

            string statement = "SELECT ProductID,ProductName,Quantity from Products";
            conn.Open();
            SqlCommand cmd = new SqlCommand(statement, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product product = new Product()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity = reader.GetInt32(2)

                    };
                    _product_lst.Add(product);
                }
            }
            conn.Close();
            return _product_lst;
        }
    }
}
