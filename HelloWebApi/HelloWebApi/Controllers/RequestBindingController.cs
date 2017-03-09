using HelloWebApi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace HelloWebApi.Controllers
{
    public class RequestBindingController : ApiController
    {
        /*public void Post(HttpRequestMessage req)
        {
            var content = req.Content.ReadAsAsync<Employee>().Result;
            int id = Int32.Parse(req.RequestUri.Segments.Last());

            Trace.WriteLine(content.Id);
            Trace.WriteLine(content.FirstName);
            Trace.WriteLine(content.LastName);
            Trace.WriteLine(content.Department);
            Trace.WriteLine(id);
        }*/

        /*public void Post(int id, string firstName, [FromBody] int locationId, Guid guid)
        {
            Trace.WriteLine(id);
            Trace.WriteLine(firstName);
            Trace.WriteLine(locationId);
            Trace.WriteLine(guid);
        }*/

        public void Post(FormDataCollection data)
        {
            Trace.WriteLine(data.Get("firstName"));
            Trace.WriteLine(data.Get("lastName"));
        }
    }
}
