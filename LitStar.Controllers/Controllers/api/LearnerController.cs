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
using LitStar.Services.Messaging.LearnerService;
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
    public class LearnerController : ApiController
    {
        private readonly ILearnerService _learnerService;
        private readonly IUserService _userService;
        public LearnerController(ILocalAuthenticationService authenticationService,
            IUserService userService,
            IExternalAuthenticationService externalAuthenticationService,
            IFormsAuthentication formsAuthentication,
            IActionArguments actionArguments, ILearnerService learnerService)
        {
            _learnerService = learnerService;
            _userService = userService;
        }

        public LearnerController() { }

        [HttpPost]
        [ActionName("CreateLearner")]
        public string CreateLearner(NewLearnerRequest request)
        {
            var user = request.User;
            var learner = request.Learner;

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

            learner.AccountID = SecurityContextManager.Current.CurrentAccount.ID;
            learner.AvatarPath = ResourceStrings.Gravatar_DefaultPic_BaseURL +
                SecurityHelper.GetMd5Hash(learner.Email) + ResourceStrings.Gravatar_DefaultPic_BaseIdenticonType;
            learner.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
            learner.DateCreated = DateTime.Now;
            learner.EnteredBy = ((IUser)SecurityContextManager.Current.CurrentUser).ID;
            learner.LastLoggedIn = DateTime.Now;
            learner.LastUpdated = DateTime.Now;
            learner.UserID = user.ID;
            learner.IsActive = true;
            
            var learnerRequest = new CreateLearnerRequest();
            learnerRequest.Learner = learner;
            _learnerService.CreateLearner(learnerRequest);

            return "1:Student Created Successfully!:/People/LearnerProfile/" + learner.ID.ToString();
        }

        [HttpPost]
        [ActionName("UpdateLearner")]
        public string UpdateLearner(Learner learner)
        {
            var request = new UpdateLearnerRequest();
            request.Learner = learner;
            LearnerView view = new LearnerView();
            view.SideBar.SelectedMenuItem = "nav-people";
            view.SideBar.SelectedSubMenuItem = "subnav-students";
            view.SelectedLearner = _learnerService.UpdateLearner(request).View.Learner;
            return "";
        }

        [HttpPost]
        [ActionName("UpdateLearnerSecurity")]
        public string UpdateLearnerSecurity(User user)
        {
            var request = new UpdateUserRequest();
            request.User = user;
            StaffView view = new StaffView();
            view.SideBar.SelectedMenuItem = "nav-people";
            view.SideBar.SelectedSubMenuItem = "subnav-students";
            _userService.UpdateUser(request);
            return "";
        }

        public class NewLearnerRequest
        {
            public User User { get; set; }
            public Learner Learner { get; set; }
        }
    }
}
