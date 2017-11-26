﻿using System;
using System.Web.Http;
using System.Web.Http.SelfHost;
using Megaphone.Core;

namespace Megaphone.WebApi
{
    public class WebApiProvider : IFrameworkProvider
    {
        public Uri Start(string serviceName, string version)
        {
            var uri = Configuration.GetUri();
            var config = new HttpSelfHostConfiguration(uri);

            // Attribute routing.
            config.MapHttpAttributeRoutes();

            // Convention-based routing.
            config.Routes.MapHttpRoute(
                "API Default", "{controller}/{id}",
                new { id = RouteParameter.Optional });

            var server = new HttpSelfHostServer(config);
            server.OpenAsync().Wait();
            return uri;
        }
    }
}
