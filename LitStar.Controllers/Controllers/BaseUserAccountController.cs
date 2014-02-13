﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using LitStar.Controllers.ActionArguments;
using LitStar.Infrastructure.Authentication;
using LitStar.Core.Domain.User;
using LitStar.Services.Interfaces;
using LitStar.Core.Security;

namespace LitStar.Controllers.Controllers
{
    public abstract class BaseUserAccountController : Controller
    {
        protected readonly ILocalAuthenticationService _authenticationService;
        protected readonly IUserService _userService;
        protected readonly IExternalAuthenticationService _externalAuthenticationService;
        protected readonly IFormsAuthentication _formsAuthentications;
        protected readonly IActionArguments _actionArguments;

        public BaseUserAccountController(
            ILocalAuthenticationService authenticationService,
            IUserService userService,
            IExternalAuthenticationService externalAuthenticationService,
            IFormsAuthentication formsAuthentication,
            IActionArguments actionArguments) 
        {
            _actionArguments = actionArguments;
            _authenticationService = authenticationService;
            _formsAuthentications = formsAuthentication;
            _externalAuthenticationService = externalAuthenticationService;
            _userService = userService;

            
        }

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (SecurityContextManager.Current == null || SecurityContextManager.Current.CurrentUser == null)
            {
                var url = new UrlHelper(filterContext.RequestContext);
                var logonUrl = url.Action("Index", "Login", new { reason = "NotAuthorized" });
                filterContext.Result = new RedirectResult(logonUrl);
            }

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

        public ActionResult RedirectBasedOn(string returnURL)
        {
            if (returnURL == ActionArgumentKey.GoToProfile.ToString())
                return RedirectToAction("Profile", "Profile");
            else if (returnURL == "Login")
                return RedirectToAction("Index", "Login");
            else
                return RedirectToAction("Index", "Home");
        }

        public ActionArgumentKey GetReturnActionFrom(string returnUrl)
        {
            if (!string.IsNullOrEmpty(returnUrl) && returnUrl.ToLower().Contains("profile"))
                return ActionArgumentKey.GoToProfile;
            else
                return ActionArgumentKey.GoToProfile;
        }
    }
}
