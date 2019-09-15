using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using Dapper;

namespace WebPortalDBUae
{
    public class EmployeeDao : IEmployeeDao
    {
        public int DeleteEmployee(int employeeId)
        {
           using(IDbConnection conn = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("sqlConn")))
            {
                return conn.Execute("sp_DeleteEmployee @id", new { id = employeeId });
            }
        }

        public List<Employee> GetAllEmployees()
        {
            using(IDbConnection conn = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("sqlConn")))
            {
                return conn.Query<Employee>("sp_GetAllEmployees").ToList();
            }
        }

        public Employee GetEmployee(int employeeId)
        {
            using(IDbConnection conn = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("sqlConn")))
            {
                return conn.Query<Employee>("sp_GetEmployee @id", new { id = employeeId }).FirstOrDefault();
            }
        }

        public List<Employee> GetEmployees()
        {
            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("sqlConn")))
            {
               return  conn.Query<Employee>("select * from  customerinfo Where ISACTIVE=1 ").ToList();
            }   
        }

        public int InsertEmployee(Employee employee)
        {
            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("sqlConn")))
            {
                return conn.Execute("sp_InsertEmployee @id, @first_name, @last_name, @salary, @city", employee);

            }
        }

        public int UpdateEmployee(Employee employee)
        {
            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("sqlConn")))
            {
                return conn.Execute("sp_UpdateEmployee @id, @first_name, @last_name, @salary, @city", employee);
            }
        }

        public int UpdateEmployee(int id, Employee employee)
        {
            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString("sqlConn")))
            {
                return conn.Execute("sp_UpdateEmployee @id, @first_name, @last_name, @salary, @city", 
                    new { id, employee.first_name, employee.last_name,employee.salary,employee.city
                });
            }
        }
    }
}
