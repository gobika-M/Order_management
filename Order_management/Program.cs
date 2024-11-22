using Order_management.Model;
using Order_management.Repository;
using Order_management.Utility;
using System;
using System.Data;

namespace Order_management
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IOrderManagement orderManagement = new OrderManagement(DBConnUtil.ConnectionString);

            while (true)
            {
                Console.WriteLine("\n----- Order Management System -----");
                Console.WriteLine("1. Create Order");
                Console.WriteLine("2. Check if User Exists");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice (1/2/3): ");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input, please try again.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        CreateOrder(orderManagement);
                        break;

                    case 2:
                        CheckIfUserExists(orderManagement);
                        break;

                    case 3:
                        Console.WriteLine("Exiting the application.");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        static void CreateOrder(IOrderManagement orderManagement)
        {
            Console.Write("Enter the user ID: ");
            int userId = int.Parse(Console.ReadLine());

            Console.Write("Enter the username of the user: ");
            string username = Console.ReadLine();

            Console.Write("Enter the password of the user: ");
            string password = Console.ReadLine();

            Console.Write("Enter the role of the user (Admin/User): ");
            string role = Console.ReadLine();
            User user = new User(userId, username, password, role);
            List<Product> products = new List<Product>();
            Console.Write("How many products do you want to add to the order? ");
            int productCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < productCount; i++)
            {
                Console.Write("Enter product type (1 for Electronics, 2 for Clothing): ");
                int productType = int.Parse(Console.ReadLine());

                Console.Write("Enter product ID: ");
                int productId = int.Parse(Console.ReadLine());

                Console.Write("Enter product name: ");
                string productName = Console.ReadLine();

                Console.Write("Enter product description: ");
                string description = Console.ReadLine();

                Console.Write("Enter product price: ");
                double productPrice = double.Parse(Console.ReadLine());

                Console.Write("Enter product quantity: ");
                int productQuantity = int.Parse(Console.ReadLine());

                string type = productType == 1 ? "Electronics" : "Clothing";
                Product product = null;
                if (productType == 1)
                {
                    Console.Write("Enter product brand: ");
                    string brand = Console.ReadLine();

                    Console.Write("Enter warranty period (months): ");
                    int warrantyPeriod = int.Parse(Console.ReadLine());
                    product = new Electronics(productId, productName, description, productPrice, productQuantity, type, brand, warrantyPeriod);
                }
                else
                {
                    Console.Write("Enter product size: ");
                    string size = Console.ReadLine();

                    Console.Write("Enter product color: ");
                    string color = Console.ReadLine();
                    product = new Clothing(productId, productName, description, productPrice, productQuantity, type, size, color);
                }
                products.Add(product);
            }

            
        }
        static void CheckIfUserExists(IOrderManagement orderManagement)
        {
            Console.Write("Enter the username to check if the user exists: ");
            string username = Console.ReadLine();

            User user = new User(0, username, "", "");

            try
            {
                bool userExists = orderManagement.IsUserExist(user);
                if (userExists)
                {
                    Console.WriteLine("User exists in the system.");
                }
                else
                {
                    Console.WriteLine("User not found in the system.");
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"Error checking user existence: {ex.Message}");
            }
        }

    }
}

