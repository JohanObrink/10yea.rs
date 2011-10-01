using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using StructureMap;

namespace TenYears.Infrastructure.ControllerFactories
{
    public class StructuremapControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null) throw new HttpException(404, string.Empty);
            return ObjectFactory.GetInstance(controllerType) as IController;
        }
    }
}