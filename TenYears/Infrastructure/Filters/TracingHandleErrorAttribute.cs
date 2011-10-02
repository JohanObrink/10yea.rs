using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TenYears.Infrastructure.Filters
{
    public class TracingHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            filterContext.HttpContext.Response.ClearContent();
            filterContext.HttpContext.Response.StatusCode = 200;
            filterContext.HttpContext.Response.ContentType = "text/plain";

            filterContext.HttpContext.Response.Write(filterContext.Exception.Message + Environment.NewLine + Environment.NewLine);
            filterContext.HttpContext.Response.Write(filterContext.Exception.StackTrace);
        }
    }
}