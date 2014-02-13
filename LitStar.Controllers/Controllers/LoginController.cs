using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using LitStar.Controllers.ActionArguments;
using LitStar.Controllers.ViewModels.UserAccount;
using LitStar.Infrastructure.Authentication;
using LitStar.Infrastructure.Session;
using LitStar.Services.Interfaces;
using LitStar.Core.Domain.User;
using LitStar.Core.Security;
using LitStar.Web.Security;
using LitStar.Services.Messaging.UserService;
using LitStar.Services.ViewModels;
using AutoMapper;

namespace LitStar.Controllers.Controllers
{
    [AllowAnonymous]
    public class LoginController: Controller
    {
        protected readonly ILocalAuthenticationService _authenticationService;
        protected readonly IUserService _userService;
        protected readonly IExternalAuthenticationService _externalAuthenticationService;
        protected readonly IFormsAuthentication _formsAuthentications;
        protected readonly IActionArguments _actionArguments;
        public LoginController(
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

        [AllowAnonymous]
        public ActionResult Index()
        {
            UserAccountView accountView = InitializeAccountViewWithIssue(false, "");
            return View(accountView);
        }

        [AllowAnonymous]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Authenticate(UserAccountView account, string returnUrl)
        {
            IUserAccount user = _authenticationService.Login(account.Email, account.Password);

            if (user.IsAuthenticated)
            {
                _formsAuthentications.SetAuthenticationToken(user.AuthenticationToken);
                if (!string.IsNullOrEmpty(returnUrl))
                    return Redirect(returnUrl);
                else
                    return RedirectToAction("Index", "Home");
            }
            else
            {
                UserAccountView accountView = InitializeAccountViewWithIssue(true, "Sorry we could not log you in. Please try again.");
                accountView.CallBackSettings.ReturnUrl = "/Login";
                return View(accountView);
            }
        }

        [AllowAnonymous]
        public ActionResult ReceiveTokenAndLogon(string token, string returnUrl)
        {
            IUserAccount user = _externalAuthenticationService.GetUserDetailsFrom(token);
            if (user.IsAuthenticated)
            {
                _formsAuthentications.SetAuthenticationToken(user.AuthenticationToken);
                GetUserRequest getUserRequest = new GetUserRequest();
                getUserRequest.UserID = Convert.ToInt16(user.AuthenticationToken);

                GetUserResponse getUserResponse = _userService.GetUser(getUserRequest);

                if (getUserResponse.UserFound)
                {
                    //return RedirectBasedOn(returnUrl);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    UserAccountView accountView = InitializeAccountViewWithIssue(true, "Sorry we could not find your user account.  If you don't have an account with us please register.");
                    accountView.CallBackSettings.ReturnUrl = returnUrl;
                    return View("LogOn", accountView);
                }
            }
            else
            {
                UserAccountView accountView = InitializeAccountViewWithIssue(true, "Sorry we could not log you in.  Please try again.");
                accountView.CallBackSettings.ReturnUrl = returnUrl;
                return View("LogOn", accountView);
            }
        }

        public ActionResult SignOut()
        {
            SecurityContextManager.Current.CurrentUser = null;
            SecurityContextManager.Current.IsAuthenticated = false;
            _formsAuthentications.SignOut();
            return RedirectToAction("Index", "Login");
        }

        [AllowAnonymous]
        private UserAccountView InitializeAccountViewWithIssue(bool hasIssue, string message)
        {
            UserAccountView userAccountView = new UserAccountView();
            userAccountView.CallBackSettings.Action = "ReceiveTokenAndLogon";
            userAccountView.CallBackSettings.Controller = "AccountLogon";
            userAccountView.HasIssue = hasIssue;
            userAccountView.Message = message;

            string returnUrl = _actionArguments
                .GetValueForArgument(ActionArgumentKey.ReturnUrl);
            userAccountView.CallBackSettings.ReturnUrl = "/Login";// GetReturnActionFrom(returnUrl).ToString();
            return userAccountView;
        }
    }
}
