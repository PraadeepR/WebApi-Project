using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPortalDBUae;
using BusinessLayer;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ClientApp
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static void Main(string[] args)
        {

            RunAsync().GetAwaiter().GetResult();
        }


        static async Task<List<Employee>> GetEmployeesAsync(string path)
        {
            List<Employee> employees = null;
            HttpResponseMessage response = await client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                employees = await response.Content.ReadAsAsync<List<Employee>>();
            }
            return employees;
        }

        static void ShowProduct(List<Employee> employees)
        {
            foreach (Employee employee in employees)
                Console.WriteLine($"Name: {employee.first_name}\tSalary: " +
                    $"{employee.salary}\tCity: {employee.city}");
        }
        static async Task RunAsync()
        {

            client.BaseAddress = new Uri("http://localhost:60390/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/xml"));

            try
            {
                string path = @"http://localhost:60390/api/Employee";
                List<Employee> employees = await GetEmployeesAsync(path);
                ShowProduct(employees);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }

        public void doOperation()
        {
            IDao obj = new Dao();

            List<Employee> employees = new List<Employee>()
            {
                new Employee { id=1, city = "Mumbai", first_name="Aakash", salary=35000, last_name="Batra"},
               new Employee { id=2, city = "Goa", first_name="Prakash", salary=37000, last_name="Katra"},
                new Employee { id=3, city = "Bangalore", first_name="Pradeep", salary=38000, last_name="Vadra"},
               new Employee { id=4, city = "Hyderabad", first_name="Nitin", salary=39000, last_name="Pitroda"}
            };

            Console.WriteLine("----------Inserting Employees One by One---------");
            foreach (Employee e in employees)
            {
                obj.GetEmployeeDao.InsertEmployee(e);
            }
            Console.WriteLine("-------------End Inserting---------");


            Console.WriteLine("----------Inserting Employees All at Once---------");
            List<Employee> addemployees = new List<Employee>()
            {
                new Employee { id=5, city = "Mumbai", first_name="Deven", salary=30000, last_name="Batra"},
               new Employee { id=6, city = "Goa", first_name="Mithiles", salary=70000, last_name="Sharma"},
                new Employee { id=7, city = "Bangalore", first_name="Ananth", salary=80000, last_name="Padmanabhand"},
               new Employee { id=8, city = "Hyderabad", first_name="Trilokesh", salary=10000, last_name="Nath"}
            };
            Console.WriteLine("----------Inserting Employees One by One---------");


            List<Employee> allemployees = obj.GetEmployeeDao.GetAllEmployees();

            foreach (Employee employee1 in allemployees)
            {
                Console.WriteLine("Employee Id = {0} {1} , Name = {2} has Salary {3} for City {4}", employee1.id, employee1.first_name, employee1.last_name, employee1.salary, employee1.city);
            }

            Console.WriteLine("---------Getting Employee id 3-----------");

            Employee employee = obj.GetEmployeeDao.GetEmployee(3);
            Console.WriteLine("Employee Id = {0} {1} , Name = {2} has Salary {3} for City {4}", employee.id, employee.first_name, employee.last_name, employee.salary, employee.city);

            Console.WriteLine("Updating Above Employee to New City Mangalore and Revised Salary");

            employee.salary = 90000;
            employee.city = "Mangalore";
            obj.GetEmployeeDao.UpdateEmployee(employee);

            Employee employeeId3 = obj.GetEmployeeDao.GetEmployee(3);
            Console.WriteLine("Employee Id = {0} {1} , Name = {2} has Salary {3} for City {4}", employeeId3.id, employeeId3.first_name, employeeId3.last_name, employeeId3.salary, employeeId3.city);

            Console.WriteLine("-----------Deleting Employee id 3 ----------------------");
            obj.GetEmployeeDao.DeleteEmployee(3);
            Console.WriteLine("Listing All Employee");

            List<Employee> employees1 = obj.GetEmployeeDao.GetAllEmployees();

            foreach (Employee employee1 in employees1)
            {
                Console.WriteLine("Employee Id = {0} {1} , Name = {2} has Salary {3} for City {4}", employee1.id, employee1.first_name, employee1.last_name, employee1.salary, employee1.city);
            }

            Console.ReadLine();
        }
    }
}
