using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using LitStar.Controllers.ActionArguments;
using LitStar.Controllers.ViewModels.UserAccount;
using LitStar.Infrastructure.Authentication;
using LitStar.Services.Interfaces;
using LitStar.Core.Domain.User;
using LitStar.Services.Messaging.UserService;

namespace LitStar.Controllers.Controllers
{
    public class UserAccountLogOnController : BaseUserAccountController
    {
        public UserAccountLogOnController(
            ILocalAuthenticationService authenticationService,
            IUserService userService,
            IExternalAuthenticationService externalAuthenticationService,
            IFormsAuthentication formsAuthentication,
            IActionArguments actionArguments) : base(authenticationService, userService, externalAuthenticationService, formsAuthentication, actionArguments)
        { 
            
        }

        public ActionResult LogOn()
        {
            UserAccountView accountView = InitializeAccountViewWithIssue(false, "");
            return View(accountView);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult LogOn(string email, string password, string returnUrl)
        {
            IUserAccount user = _authenticationService.Login(email, password);

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
                accountView.CallBackSettings.ReturnUrl = GetReturnActionFrom(returnUrl).ToString();
                return View("LogOn", accountView);
            }
        }

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
                    return RedirectBasedOn(returnUrl);
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
            _formsAuthentications.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private UserAccountView InitializeAccountViewWithIssue(bool hasIssue, string message)
        {
            UserAccountView userAccountView = new UserAccountView();
            userAccountView.CallBackSettings.Action = "ReceiveTokenAndLogon";
            userAccountView.CallBackSettings.Controller = "AccountLogon";
            userAccountView.HasIssue = hasIssue;
            userAccountView.Message = message;

            string returnUrl = _actionArguments
                .GetValueForArgument(ActionArgumentKey.ReturnUrl);
            userAccountView.CallBackSettings.ReturnUrl = GetReturnActionFrom(returnUrl).ToString();
            return userAccountView;
        }
    }
}
