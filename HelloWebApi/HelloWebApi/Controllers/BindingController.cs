using HelloWebApi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HelloWebApi.Controllers
{
    public class BindingController : ApiController
    {
        public void Post(HttpRequestMessage req)
        {
            var content = req.Content.ReadAsAsync<Employee>().Result;
            int id = Int32.Parse(req.RequestUri.Segments.Last());

            Trace.WriteLine(content.Id);
            Trace.WriteLine(content.FirstName);
            Trace.WriteLine(content.LastName);
            Trace.WriteLine(content.Department);
            Trace.WriteLine(id);
        }
    }
}
