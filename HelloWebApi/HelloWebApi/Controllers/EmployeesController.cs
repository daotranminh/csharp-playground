using HelloWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
        public IEnumerable<Employee> Get()
        {
            return list;
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

        // PUT api/employees/12345
        public void Put(int id, Employee employee)
        {
            int index = list.ToList().FindIndex(e => e.Id == id);
            list[index] = employee;
        }

        // DELETE api/employees/12345
        public void Delete(int id)
        {
            Employee employee = list.FirstOrDefault(e => e.Id == id);
            list.Remove(employee);
        }
    }
}
