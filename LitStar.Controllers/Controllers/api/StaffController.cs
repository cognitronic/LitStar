using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net;
using AutoMapper;
using StructureMap;
using Newtonsoft.Json;
using LitStar.Controllers.ViewModels.People;
using LitStar.Controllers.ViewModels;
using LitStar.Infrastructure.CookieStorage;
using LitStar.Services.Interfaces;
using LitStar.Services.Messaging.StaffService;
using LitStar.Services.Messaging.UserService;
using LitStar.Infrastructure.Authentication;
using LitStar.Infrastructure.Helpers;
using LitStar.Core.Domain.User;
using LitStar.Core.Security;
using LitStar.Core;
using LitStar.Controllers.ActionArguments;
using LitStar.Controllers;

namespace LitStar.Controllers.Controllers.api
{
    public class StaffController : ApiController
    {
        private readonly IStaffService _staffService;
        private readonly IUserService _userService;
        public StaffController(ILocalAuthenticationService authenticationService,
            IUserService userService,
            IExternalAuthenticationService externalAuthenticationService,
            IFormsAuthentication formsAuthentication,
            IActionArguments actionArguments, IStaffService staffService)
        {
            _staffService = staffService;
            _userService = userService;
        }

        public StaffController() { }

        [HttpPost]
        [ActionName("UpdateStaff")]
        public string UpdateStaff(Staff staff)
        {
            var request = new UpdateStaffRequest();
            request.Staff = staff;
            StaffView view = new StaffView();
            view.SideBar.SelectedMenuItem = "nav-people";
            view.SideBar.SelectedSubMenuItem = "subnav-staff";
            //view.Managers.List = _staffService.
            //    GetManagers().
            //    Staff.Select(x => new SelectListItem
            //    {
            //        Value = x.ID.ToString(),
            //        Text = x.FirstName + " " + x.LastName
            //    });
            view.SelectedStaff = _staffService.UpdateStaff(request).View.Staff;
            return "";
        }

        [HttpPost]
        [ActionName("UpdateStaffSecurity")]
        public string UpdateStaffSecurity(User user)
        {
            var request = new UpdateUserRequest();
            request.User = user;
            StaffView view = new StaffView();
            view.SideBar.SelectedMenuItem = "nav-people";
            view.SideBar.SelectedSubMenuItem = "subnav-staff";
            //view.Managers.List = _staffService.
            //    GetManagers().
            //    Staff.Select(x => new SelectListItem
            //    {
            //        Value = x.ID.ToString(),
            //        Text = x.FirstName + " " + x.LastName
            //    });
            _userService.UpdateUser(request);
            return "";
        }

        [HttpPost]
        [ActionName("CreateStaff")]
        public string CreateStaff(NewStaffRequest request)
        {
            var user = request.User;
            var staff = request.Staff;

            user.AccountID = SecurityContextManager.Current.CurrentAccount.ID;
            user.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
            user.DateCreated = DateTime.Now;
            user.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
            user.LastLoggedIn = DateTime.Now;
            user.LastUpdated = DateTime.Now;
            user.UserType = UserType.Staff;
            var userRequest = new CreateUserRequest();
            userRequest.view.UserRef = user;
            _userService.CreateUser(userRequest);

            staff.AccountID = SecurityContextManager.Current.CurrentAccount.ID;
            staff.AvatarPath = ResourceStrings.Gravatar_DefaultPic_BaseURL +
                SecurityHelper.GetMd5Hash(staff.Email) + ResourceStrings.Gravatar_DefaultPic_BaseIdenticonType;
            staff.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
            staff.DateCreated = DateTime.Now;
            staff.EnteredBy = ((IUser)SecurityContextManager.Current.CurrentUser).ID;
            staff.LastLoggedIn = DateTime.Now;
            staff.LastUpdated = DateTime.Now;
            staff.UserID = user.ID;
            var staffRequest = new CreateStaffRequest();
            staffRequest.Staff = staff;
            _staffService.CreateStaff(staffRequest);

            return "";
        }

        public class NewStaffRequest
        {
            public User User { get; set; }
            public Staff Staff { get; set; }
        }
    }
}
