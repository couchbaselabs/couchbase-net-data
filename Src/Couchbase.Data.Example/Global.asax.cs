using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Couchbase.Configuration.Client;
using Newtonsoft.Json;

namespace Couchbase.Data.Example
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var config = new ClientConfiguration
            {
                SerializationSettings = new JsonSerializerSettings
                {
                    ContractResolver = new IgnoreIdContractResolver()
                }
            };
            ClusterHelper.Initialize(config);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ErrorHandlingConfig.ConfigureErrorHandling();
        }
    }
}
