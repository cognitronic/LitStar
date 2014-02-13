using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using LitStar.Infrastructure.CookieStorage;
using LitStar.Core.Security;

namespace LitStar.Controllers.Controllers
{
    public class BaseController : Controller
    {
        private readonly ICookieStorageService _cookieStorageService;

        public BaseController(ICookieStorageService cookieStorageService)
        {
            _cookieStorageService = cookieStorageService;
            
            if (SecurityContextManager.Current.CurrentUser == null)
            {
                RedirectToAction("Index", "Logon");
            }
        }

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            var skipAuthorization = filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) ||
                            filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(
                                typeof(AllowAnonymousAttribute), true);
            if (!skipAuthorization)
            {
                base.OnAuthorization(filterContext);
                if (SecurityContextManager.Current != null &&
                    SecurityContextManager.Current.CurrentUser != null &&
                    !SecurityContextManager.Current.IsAuthenticated)//Implement your own logic here
                {
                    var url = new UrlHelper(filterContext.RequestContext);
                    var logonUrl = url.Action("Index", "Login", new { reason = "NotAuthorized" });
                    filterContext.Result = new RedirectResult(logonUrl);

                }
            }
        }
    }
}
