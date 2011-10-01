using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TenYears.Infrastructure.Bootstrappers;
using System.Web.Mvc;
using TenYears.Infrastructure.ControllerFactories;

[assembly: WebActivator.PreApplicationStartMethod(typeof(TenYears.Infrastructure.AppStart_Structuremap), "Start")]
namespace TenYears.Infrastructure
{
    public static class AppStart_Structuremap
    {
        public static void Start()
        {
            new DefaultBootstrapper().BootstrapStructureMap();
            ControllerBuilder.Current.SetControllerFactory(new StructuremapControllerFactory());
        }
    }
}