using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using LitStar.Web.Security;
using LitStar.Core.Security;
using System.Web.Routing;

namespace LitStar.Controllers
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class LitStarAuthorizeAttribute : AuthorizeAttribute
    {
        //public LitStarAuthorizeAttribute(params object[] roles)
        //{
        //    if (roles.Any(r => r.GetType().BaseType != typeof(Enum)))
        //        throw new ArgumentException("Security Roles");

        //    this.Roles = string.Join(",", roles.Select(r => Enum.GetName(r.GetType(), r)));
        //}

        protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
        {
            if (SecurityContextManager.Current != null && SecurityContextManager.Current.CurrentUser != null)
                return true;
            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (SecurityContextManager.Current == null || SecurityContextManager.Current.CurrentUser == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary 
                        {
                            { "action", "Index" },
                            { "controller", "Login" }
                        });
            }
            else
                base.HandleUnauthorizedRequest(filterContext);
        }

        
    }
}
