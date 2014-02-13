using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using StructureMap;
using System.Web.Routing;
using LitStar.Core.Security;
using LitStar.Web.Security;
using LitStar.Infrastructure.Session;

namespace LitStar.Controllers
{
    public class IoCControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (SecurityContextManager.Current == null)
                SecurityContextManager.Current = new WebSecurityContext();
            if (SessionManager.Current == null)
                SessionManager.Current = new WebSessionProvider();

            return ObjectFactory.GetInstance(controllerType) as IController;
        }
    }
}
