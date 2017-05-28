using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CourseLearning.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
 
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver { IgnoreSerializableAttribute = true };
            config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            // Web API routes
            config.MapHttpAttributeRoutes();

            //var cors = new EnableCorsAttribute("*", "*", "*") { SupportsCredentials = true };
            //config.EnableCors(cors);

            config.Routes.MapHttpRoute(
                name: "AdminApi",
                routeTemplate: "api/admin/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
            name: "ClientApi",
            routeTemplate: "api/client/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
        );
            config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
        );
        }
    }
}
