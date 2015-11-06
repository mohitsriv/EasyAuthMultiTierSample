using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using MyDashAPI.DAL;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Configuration;

namespace MyDashAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer<TodoListServiceContext>(new TodoListServiceInitializer());
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var secretsFile = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "secrets.json");
            if (File.Exists(secretsFile))
            {
                using (var reader = new StreamReader(secretsFile))
                {
                    using (var jsonReader = new JsonTextReader(reader))
                    {
                        var serializer = new JsonSerializer();
                        var json = serializer.Deserialize<JObject>(jsonReader);
                        foreach (var entry in json)
                        {
                            ConfigurationManager.AppSettings.Set(entry.Key, (string)entry.Value);
                        }
                    }
                }
            }
        }
    }
}
