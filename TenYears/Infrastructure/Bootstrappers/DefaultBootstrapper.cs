using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;
using TenYears.Services;
using TenYears.Services.MongoServices;
using MongoDB.Driver;
using System.Configuration;

namespace TenYears.Infrastructure.Bootstrappers
{
    public class DefaultBootstrapper
    {
        private bool hasStarted = false;

        public virtual void BootstrapStructureMap()
        {
            if (hasStarted)
                ObjectFactory.ResetDefaults();

            ObjectFactory.Initialize(x =>
            {
                x.For<IPersonService>().HttpContextScoped().Use<MongoPersonService>();
                x.For<ITimelineService>().HttpContextScoped().Use<MongoTimelineService>();

                x.For<MongoDatabase>().HttpContextScoped().Use(() => {
                    var connectionString = ConfigurationManager.AppSettings["MONGOHQ_URL"];
                    var server = MongoServer.Create(connectionString);

                    return server.GetDatabase(connectionString.Substring(connectionString.LastIndexOf("/") +1);
                });
            });
        }
    }
}