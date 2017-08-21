using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Gighub
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //var setting = GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings;
            //setting.ContractResolver = new CamelCasepropertyContractResolver();
            //config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
