using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Diagnostics;
using HelloWebApi.Models;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;

namespace HelloWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.MediaTypeMappings.Add(
                new QueryStringMapping("frmt", "json", new MediaTypeHeaderValue("application/json")));

            config.Formatters.JsonFormatter.MediaTypeMappings.Add(
                new RequestHeaderMapping("X-Media", "json", StringComparison.OrdinalIgnoreCase, false,
                              new MediaTypeHeaderValue("application/json")));

            config.Formatters.XmlFormatter.MediaTypeMappings.Add(
                new QueryStringMapping("frmt", "xml", new MediaTypeHeaderValue("application/xml")));
            
            foreach (var formatter in config.Formatters)
            {
                Trace.WriteLine(formatter.GetType().Name);
                Trace.WriteLine("   CanReadType:  " + formatter.CanReadType(typeof(Employee)));
                Trace.WriteLine("   CanWriteType: " + formatter.CanWriteType(typeof(Employee)));
                Trace.WriteLine("   Base:         " + formatter.GetType().BaseType.Name);
                Trace.WriteLine("   Media Types:  " + String.Join(", ", formatter.SupportedMediaTypes));
            }
        }
    }
}
