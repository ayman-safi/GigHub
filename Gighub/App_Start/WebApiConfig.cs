﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
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
            var settings = GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.Formatting = Formatting.Indented;

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
