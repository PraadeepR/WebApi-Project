using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPortalDBUae
{
    public class Dao : IDao
    {
        public EmployeeDao GetEmployeeDao
        {
            get { return new EmployeeDao(); }
        }   
    }
}
