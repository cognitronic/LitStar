using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Controllers.ViewModels.UserAccount;
using LitStar.Controllers.ViewModels;
using LitStar.Infrastructure.CookieStorage;
using LitStar.Services.Interfaces;
using LitStar.Services.Messaging.UserService;
using LitStar.Infrastructure.Authentication;
using LitStar.Core.Domain.User;
using LitStar.Controllers.ActionArguments;
using LitStar.Controllers;
using System.Web.Mvc;
using LitStar.Core.Security;

namespace LitStar.Controllers.Controllers
{
    public class TopNavBarController : BaseUserAccountController
    {
        public TopNavBarController(ILocalAuthenticationService authenticationService,
            IUserService userService,
            IExternalAuthenticationService externalAuthenticationService,
            IFormsAuthentication formsAuthentication,
            IActionArguments actionArguments)
            : base(authenticationService, userService, externalAuthenticationService, formsAuthentication, actionArguments)
        {

        }

        [ChildActionOnly]
        public ActionResult Menu()
        {
            var viewModel = new TopNavBarView();
            viewModel.SelectedUser = SecurityContextManager.Current.CurrentUser;

            return PartialView("_TopNavBarPartial", viewModel);
        }
    }
}
