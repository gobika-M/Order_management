using Order_management.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_management.Repository
{
    internal interface IOrderManagement
    {
        void CreateOrder(User user, List<Product> products);
        bool IsUserExist(User user);
    }
}
