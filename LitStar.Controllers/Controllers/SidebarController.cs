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
    public class SidebarController : BaseUserAccountController
    {
        public SidebarController(ILocalAuthenticationService authenticationService,
            IUserService userService,
            IExternalAuthenticationService externalAuthenticationService,
            IFormsAuthentication formsAuthentication,
            IActionArguments actionArguments)
            : base(authenticationService, userService, externalAuthenticationService, formsAuthentication, actionArguments)
        {

        }

        [ChildActionOnly]
        public ActionResult Navigation(string selectedItem, string selectedSubItem)
        {
            var view = new SideBarView();
            switch (((User)SecurityContextManager.Current.CurrentUser).Type)
            {
                case "User":
                case "Staff":
                    view.SelectedSideBar = SideBarTypes.StaffSideBar.ToString();
                    view.SelectedMenuItem = selectedItem;
                    view.SelectedSubMenuItem = selectedSubItem;
                    if (SecurityContextManager.Current.CurrentProfile == null)
                    {
                        view.ProfileImagePath = ((User)SecurityContextManager.Current.CurrentUser).AvatarPath;
                        view.SelectedProfileName = ((User)SecurityContextManager.Current.CurrentUser).FirstName + " " + ((User)SecurityContextManager.Current.CurrentUser).LastName;
                    }
                    else 
                    {
                        view.ProfileImagePath = ((IUser)SecurityContextManager.Current.CurrentProfile).AvatarPath;
                        view.SelectedProfileName = ((IUser)SecurityContextManager.Current.CurrentProfile).FirstName + " " + ((IUser)SecurityContextManager.Current.CurrentProfile).LastName;
                    }
                    break;
                    break;
            }
            return PartialView("_SideBarPartial", view);
        }
    }
}
