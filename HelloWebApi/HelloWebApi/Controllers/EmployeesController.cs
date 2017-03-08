using HelloWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;

namespace HelloWebApi.Controllers
{
    public class EmployeesController : ApiController
    {
        private static IList<Employee> list = new List<Employee>()
        {
            new Employee() { Id = 12345, FirstName = "John", LastName = "Human", Department = 2 },
            new Employee() { Id = 12346, FirstName = "Jane", LastName = "Public", Department = 3 },
            new Employee() { Id = 12347, FirstName = "Joseph", LastName = "Law", Department = 2 }
        };

        // Action methods
        // GET api/employees
        //public IEnumerable<Employee> Get()
        public HttpResponseMessage Get()
        {
            //return list;
            var values = list.Select(
                e => new {
                    Identifier = e.Id,
                    Name = e.FirstName + " " + e.LastName
                });

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent(values.GetType(), values, Configuration.Formatters.JsonFormatter)
            };

            return response;
        }

        // GET api/employees/12345
        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage msg = null;
            var employee = list.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                msg = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee not found!");
            }
            else
            {
                msg = Request.CreateResponse<Employee>(HttpStatusCode.OK, employee);
            }

            return msg;
        }

        public IEnumerable<Employee> GetByDepartment(int department)
        {
            return list.Where(e => e.Department == department);
        }

        // POST api/employees
        public HttpResponseMessage Post(Employee employee)
        {
            int maxId = list.Max(e => e.Id);
            employee.Id = maxId + 1;
            list.Add(employee);

            HttpResponseMessage response
                = Request.CreateResponse<Employee>(HttpStatusCode.Created, employee);

            string uri = Url.Link("DefaultApi", new { id = employee.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        // POST api/employees/id
        public HttpResponseMessage Post(int id, Employee employee)
        {
            int index = list.ToList().FindIndex(e => e.Id == id);

            if (index >= 0)
            {
                list[index] = employee;

                return Request.CreateResponse(HttpStatusCode.NoContent);
            }

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with id " + id + "not found!");
        }

        // PUT api/employees/12345
        public HttpResponseMessage Put(int id, Employee employee)
        {
            int index = list.ToList().FindIndex(e => e.Id == id);
            if (index >= 0)
            {
                list[index] = employee;
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                list.Add(employee);

                HttpResponseMessage response
                    = Request.CreateResponse<Employee>(HttpStatusCode.Created, employee);

                string uri = Url.Link("DefaultApi", new { id = employee.Id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
        }

        // PATCH api/employees/12345
        public HttpResponseMessage Patch(int id, Delta<Employee> deltaEmployee)
        {
            var employee = list.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with id = " + id + "not found!");
            }

            deltaEmployee.Patch(employee);

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        // DELETE api/employees/12345
        public void Delete(int id)
        {
            Employee employee = list.FirstOrDefault(e => e.Id == id);
            list.Remove(employee);
        }
    }
}
