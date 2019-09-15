using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLayer;
using WebPortalDBUae;

namespace WebApi.Controllers
{
    public class EmployeeController : ApiController
    {

        // GET: api/Employee
        public IEnumerable<Employee> Get()
        {
            IDao obj = new Dao();
            return obj.GetEmployeeDao.GetAllEmployees();
        }

        // GET: api/Employee/5
        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage httpResponseMessage = null;
            try
            {
                IDao obj = new Dao();
                Employee employee = obj.GetEmployeeDao.GetEmployee(id);
                if (employee != null)
                    httpResponseMessage = Request.CreateResponse<Employee>(HttpStatusCode.OK, employee);
                else
                    httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format("Employee with ID {0} not Found", id));
            }
            catch (Exception ex)
            {
                httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return httpResponseMessage;
        }

        // POST: api/Employee
        public HttpResponseMessage Post([FromBody]Employee employee)
        {
            HttpResponseMessage httpResponseMessage = null;
            try
            {
                IDao obj = new Dao();

                int id = obj.GetEmployeeDao.InsertEmployee(employee);

                httpResponseMessage = Request.CreateResponse(HttpStatusCode.Created, employee);
                httpResponseMessage.Headers.Location = new Uri(Request.RequestUri + employee.id.ToString());

            }
            catch (Exception ex)
            {
                httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return httpResponseMessage;

        }

        // PUT: api/Employee/5
        public HttpResponseMessage Put(int id, [FromBody]Employee employee)
        {
            HttpResponseMessage httpResponseMessage = null;
            try
            {
                IDao obj = new Dao();

                Employee existingEmployee = obj.GetEmployeeDao.GetEmployee(id);
                if(existingEmployee != null)
                {
                    obj.GetEmployeeDao.UpdateEmployee(id, employee);
                    httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, employee);
                    httpResponseMessage.Headers.Location = new Uri(Request.RequestUri + employee.id.ToString());
                }
                else
                {
                    httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format("Employee Id {0} Not Found ",id));
                }
                
            }
            catch(Exception ex)
            {
                httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return httpResponseMessage;
        }

        // DELETE: api/Employee/5
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage httpResponseMessage = null;

            try
            {
                IDao obj = new Dao();
                int deleteCount = obj.GetEmployeeDao.DeleteEmployee(id);
                if (deleteCount == 0)
                    httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format("Employee With ID {0} Not Found to Delete", id));
                else
                    httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, string.Format("Employee With ID {0} Is Deleted Successfully", id));
            }
            catch (Exception ex)
            {
                httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return httpResponseMessage;
        }
    }
}
