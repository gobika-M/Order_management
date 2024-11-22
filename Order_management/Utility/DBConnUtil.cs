using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_management.Utility
{
    internal class DBConnUtil
    {
        static void Main()
        {
            GetAppSettingsFile();
        }

        private static void GetAppSettingsFile() { 
            var builder =new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json");
            

        }



    }
}

