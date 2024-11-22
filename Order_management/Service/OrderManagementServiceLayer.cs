using Order_management.Model;
using Order_management.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_management.Service
{
    internal class OrderManagementServiceLayer
    {
        IOrderManagement repo = new OrderManagement();

        public void createProduct()
        {
            try
            {
                Console.WriteLine("Enter User Name : ");
                String userName = Console.ReadLine();

                Console.WriteLine("Enter Password : ");
                String password = Console.ReadLine();

                Console.WriteLine("Enter Role[ Admin | User ] : ");
                String role = Console.ReadLine();

                User user = new User(userName, password, role);

                Console.WriteLine("Enter Product Name : ");
                String productName = Console.ReadLine();

                Console.WriteLine("Enter Description : ");
                String description = Console.ReadLine();

                Console.WriteLine("Enter Price : ");
                double price = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter Quantity In Stock : ");
                int qis = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Type : ");
                String type = Console.ReadLine();

                Product product = new Product(productName, description, price, qis, type);

                if (repo.createProduct(user, product))
                {
                    Console.WriteLine("Product Created successfully!");
                    return;
                }
                else
                {
                    Console.WriteLine("Product Creation Failed!");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void createOrder()
        {
            List<Product> products = new List<Product>();
            try
            {
                Console.WriteLine("Enter User Name : ");
                String userName = Console.ReadLine();

                Console.WriteLine("Enter Password : ");
                String password = Console.ReadLine();

                Console.WriteLine("Enter Role[ Admin | User ] : ");
                String role = Console.ReadLine();

                User user = new User(userName, password, role);

                String next = "yes";
                while (next == "yes")
                {
                    Console.WriteLine("Enter Product Name : ");
                    String productName = Console.ReadLine();

                    Console.WriteLine("Enter Description : ");
                    String description = Console.ReadLine();

                    Console.WriteLine("Enter Price : ");
                    double price = double.Parse(Console.ReadLine());

                    Console.WriteLine("Enter Quantity In Stock : ");
                    int qis = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter Type : ");
                    String type = Console.ReadLine();

                    Console.WriteLine("want to continue(yes/n) : ");
                    next = Console.ReadLine();

                    Product product = new Product(productName, description, price, qis, type);
                    products.Add(product);
                }
                if (repo.createOrder(user, products))
                {
                    Console.WriteLine("Order Created Successfully !");
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void cancelOrder()
        {
            try
            {
                Console.WriteLine("Enter user ID : ");
                int userId = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Order ID : ");
                int orderId = int.Parse(Console.ReadLine());

                if (repo.cancelOrder(userId, orderId))
                {
                    Console.WriteLine("Order cancelled successfully !");
                    return;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        public void createUser()
        {
            try
            {
                Console.WriteLine("Enter User Name : ");
                String userName = Console.ReadLine();

                Console.WriteLine("Enter Password : ");
                String password = Console.ReadLine();

                Console.WriteLine("Enter Role(Admin/User) : ");
                String role = Console.ReadLine();

                User user = new User(userName, password, role);

                if (repo.createUser(user))
                {
                    Console.WriteLine("User created successfully !");
                    return;
                }
                else
                {
                    Console.WriteLine("User Creation Failed!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        public void getAllProducts()
        {
            try
            {
                List<Product> product = repo.getAllProducts();
                foreach (Product productItem in product)
                {
                    Console.WriteLine(productItem.ToString());
                    Console.WriteLine("-------------------------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }



        public void getOrderByUser()
        {
            try
            {
                Console.WriteLine("Enter User Name : ");
                String userName = Console.ReadLine();

                Console.WriteLine("Enter Password : ");
                String password = Console.ReadLine();

                Console.WriteLine("Enter Role(Admin/User) : ");
                String role = Console.ReadLine();

                User user = new User(userName, password, role);

                List<Product> product = repo.getOrderByUser(user);
                foreach (Product productItem in product)
                {
                    Console.WriteLine(productItem.ToString());
                    Console.WriteLine("-------------------------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
