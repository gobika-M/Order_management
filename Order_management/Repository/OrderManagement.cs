using Order_management.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_management.Repository
{
    internal class OrderManagement: IOrderManagement
    {
        private readonly string _connectionString;

        public OrderManagement(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreateOrder(User user, List<Product> products)
        {
            if (!IsUserExist(user))
            {
                throw new System.Exception("User not found in database.");
            }
            Console.WriteLine("Order created successfully for user: " + user.Username);
        }

        public bool IsUserExist(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", user.Username);
                    int userCount = (int)command.ExecuteScalar();
                    return userCount > 0;
                }
            }
        }
    }
}
