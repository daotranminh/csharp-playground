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
            string content = req.Content.ReadAsStringAsync().Result;
            int id = Int32.Parse(req.RequestUri.Segments.Last());

            Trace.WriteLine(content);
            Trace.WriteLine(id);
        }
    }
}
