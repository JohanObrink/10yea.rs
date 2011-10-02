using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: WebActivator.PreApplicationStartMethod(typeof(TenYears.Infrastructure.AppStart.AppStart), "Start")]
namespace TenYears.Infrastructure.AppStart
{
    public static class AppStart
    {
        public static void Start()
        {
            AppStart_Structuremap.Start();
            AppStart_MongoDB.Start();
        }
    }
}