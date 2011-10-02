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
                    var server = MongoServer.Create(ConfigurationManager.AppSettings["MONGOHQ_URL"]);

                    return server.GetDatabase("10years");
                });
            });
        }
    }
}