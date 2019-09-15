using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace WebPortalDBUae
{
    public interface IEmployeeDao
    {
        List<Employee> GetEmployees();

        int DeleteEmployee(int employeeId);

        int UpdateEmployee(Employee employee);

        int UpdateEmployee(int id, Employee employee);

        int InsertEmployee(Employee employee);
        

        List<Employee> GetAllEmployees();

        Employee GetEmployee(int employeeId);           
    }
}
