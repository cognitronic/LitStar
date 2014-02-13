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
using LitStar.Services.Messaging.TutorService;
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
    public class TutorController  : ApiController
    {
        private readonly ITutorService _tutorService;
        private readonly IUserService _userService;

        public TutorController(ILocalAuthenticationService authenticationService,
            IUserService userService,
            IExternalAuthenticationService externalAuthenticationService,
            IFormsAuthentication formsAuthentication,
            IActionArguments actionArguments, 
            ITutorService tutorService)
        {
            _tutorService = tutorService;
            _userService = userService;
        }

        public TutorController() { }

        [HttpPost]
        [ActionName("CreateTutor")]
        public string CreateTutor(NewTutorRequest request)
        {
            var user = request.User;
            var tutor = request.Tutor;

            user.AccountID = SecurityContextManager.Current.CurrentAccount.ID;
            user.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
            user.DateCreated = DateTime.Now;
            user.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
            user.LastLoggedIn = DateTime.Now;
            user.LastUpdated = DateTime.Now;
            user.UserType = UserType.Learner;
            var userRequest = new CreateUserRequest();
            userRequest.view.UserRef = user;
            _userService.CreateUser(userRequest);

            tutor.AccountID = SecurityContextManager.Current.CurrentAccount.ID;
            tutor.AvatarPath = ResourceStrings.Gravatar_DefaultPic_BaseURL +
                SecurityHelper.GetMd5Hash(tutor.Email) + ResourceStrings.Gravatar_DefaultPic_BaseIdenticonType;
            tutor.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
            tutor.DateCreated = DateTime.Now;
            tutor.EnteredBy = ((IUser)SecurityContextManager.Current.CurrentUser).ID;
            tutor.LastLoggedIn = DateTime.Now;
            tutor.LastUpdated = DateTime.Now;
            tutor.UserID = user.ID;
            tutor.IsActive = true;

            var tutorRequest = new CreateTutorRequest();
            tutorRequest.Tutor = tutor;
            _tutorService.CreateTutor(tutorRequest);
            

            return "1:Tutor Created Successfully!:/People/TutorProfile/" + tutor.ID.ToString();
        }

        [HttpPost]
        [ActionName("UpdateTutor")]
        public string UpdateTutor(Tutor tutor)
        {
            var request = new UpdateTutorRequest();
            request.Tutor = tutor;
            TutorView view = new TutorView();
            view.SideBar.SelectedMenuItem = "nav-people";
            view.SideBar.SelectedSubMenuItem = "subnav-instructors";
            view.SelectedTutor = _tutorService.UpdateTutor(request).View.Tutor;
            return "";
        }

        [HttpPost]
        [ActionName("UpdateTutorSecurity")]
        public string UpdateTutorSecurity(User user)
        {
            var request = new UpdateUserRequest();
            request.User = user;
            StaffView view = new StaffView();
            view.SideBar.SelectedMenuItem = "nav-people";
            view.SideBar.SelectedSubMenuItem = "subnav-instructors";
            _userService.UpdateUser(request);
            return "";
        }

        public class NewTutorRequest
        {
            public User User { get; set; }
            public Tutor Tutor { get; set; }
        }
    }
}

