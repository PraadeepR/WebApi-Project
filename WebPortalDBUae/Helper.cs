using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPortalDBUae
{
    public static class Helper
    {
        public static string GetConnectionString(string connecName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[connecName].ConnectionString;
            return connectionString;
        }

    }
}
