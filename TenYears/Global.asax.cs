using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TenYears
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.ico/{*pathInfo}");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Testimonials", // Route name
                "{id}/{name}", // URL with parameters
                new { controller = "testimonials", action = "show", id = UrlParameter.Optional, name = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
                "Timeline", // Route name
                "timeline/{action}/{id}", // URL with parameters
                new { controller = "Timeline", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);


        }

        protected void Application_Error()
        {
            var ex = Server.GetLastError();

            Response.Clear();
            Response.ContentType = "text/plain";
            Response.StatusCode = 200;

            var thisEx = ex;
            while (thisEx != null)
            {
                Response.Write("== Message: " + Environment.NewLine + thisEx.Message + Environment.NewLine + Environment.NewLine);
                thisEx = thisEx.InnerException;
            }

            Response.Write("== StackTrace:" + Environment.NewLine + ex.StackTrace);
            Response.Flush();
            Response.End();
        }
    }
}