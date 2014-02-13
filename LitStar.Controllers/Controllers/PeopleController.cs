using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Controllers.ViewModels.People;
using LitStar.Controllers.ViewModels;
using LitStar.Infrastructure.CookieStorage;
using LitStar.Services.Interfaces;
using LitStar.Services.Messaging.StaffService;
using LitStar.Services.Messaging.LearnerService;
using LitStar.Services.Messaging.TutorService;
using LitStar.Infrastructure.Authentication;
using LitStar.Core.Domain.User;
using LitStar.Controllers.ActionArguments;
using LitStar.Controllers;
using System.Web.Mvc;
using LitStar.Core.Security;
using EO.Pdf;

namespace LitStar.Controllers.Controllers
{
    public class PeopleController : BaseUserAccountController
    {
        private readonly IStaffService _staffService;
        private readonly ITutorService _tutorService;
        private readonly ILearnerService _learnerService;
        public PeopleController(ILocalAuthenticationService authenticationService,
            IUserService userService,
            ITutorService tutorService,
            IExternalAuthenticationService externalAuthenticationService,
            IFormsAuthentication formsAuthentication,
            ILearnerService learnerService,
            IActionArguments actionArguments, IStaffService staffService)
            : base(authenticationService, userService, externalAuthenticationService, formsAuthentication, actionArguments)
        {
            _staffService = staffService;
            _tutorService = tutorService;
            _learnerService = learnerService;
            SecurityContextManager.Current.CurrentProfile = null;
        }

        #region Staff
        public ActionResult Staff()
        {
            StaffView view = new StaffView();
            view.SideBar.SelectedMenuItem = "nav-people";
            view.SideBar.SelectedSubMenuItem = "subnav-staff";
            view.StaffList = _staffService.GetStaffList().Staff.ToList<IStaff>();
            return View(view);
        }

        public ActionResult StaffProfile(int id)
        {
            StaffView view = new StaffView();
            view.SideBar.SelectedMenuItem = "nav-people";
            view.SideBar.SelectedSubMenuItem = "subnav-staff";
            view.Managers.List = _staffService.
                GetManagers().
                Staff.Select(x => new SelectListItem
                {
                    Value = x.ID.ToString(),
                    Text = x.FirstName + " " + x.LastName
                });
            GetStaffResponse response = new GetStaffResponse();
            response = _staffService.GetStaffByID(id);
            SecurityContextManager.Current.CurrentProfile = response.Staff;
            view.SelectedStaff = response.Staff;
            return View(view);
        }

        public ActionResult UpdateStaff(Staff staff)
        {
            var request = new UpdateStaffRequest();
            request.Staff = staff;
            StaffView view = new StaffView();
            view.SideBar.SelectedMenuItem = "nav-people";
            view.SideBar.SelectedSubMenuItem = "subnav-staff";
            view.Managers.List = _staffService.
                GetManagers().
                Staff.Select(x => new SelectListItem
                {
                    Value = x.ID.ToString(),
                    Text = x.FirstName + " " + x.LastName
                });
            view.SelectedStaff = _staffService.UpdateStaff(request).View.Staff;
            return View("StaffProfile", view);
        }

        public ActionResult CreateStaff()
        {
            StaffView view = new StaffView();
            view.SideBar.SelectedMenuItem = "nav-people";
            view.SideBar.SelectedSubMenuItem = "subnav-staff";
            view.Managers.List = _staffService.
                GetManagers().
                Staff.Select(x => new SelectListItem
                {
                    Value = x.ID.ToString(),
                    Text = x.FirstName + " " + x.LastName
                });
            view.SelectedStaff = new Staff();
            return View(view);
        }
        #endregion

        #region Learner
        public ActionResult Learners()
        {
            LearnerView view = new LearnerView();
            view.SideBar.SelectedMenuItem = "nav-people";
            view.SideBar.SelectedSubMenuItem = "subnav-students";
            view.LearnerList = _learnerService.GetLearnerList().Learners.ToList<ILearner>();
            return View(view);
        }

        public ActionResult LearnerProfile(int id)
        {
            LearnerView view = new LearnerView();
            view.SideBar.SelectedMenuItem = "nav-people";
            view.SideBar.SelectedSubMenuItem = "subnav-students";
            var ethnicities = from EthnicityType e in Enum.GetValues(typeof(EthnicityType))
                              select new { Value = e, Text = e.ToString().Replace("_", " ") };
            view.Ethnicities = new SelectList(ethnicities, "Value", "Text");
            var educationlevel = from EducationLevel e in Enum.GetValues(typeof(EducationLevel))
                              select new { Value = e, Text = e.ToString().Replace("_", " ") };
            view.EducationLevels = new SelectList(educationlevel, "Value", "Text");
            GetLearnerResponse response = new GetLearnerResponse();
            response = _learnerService.GetLearnerByID(id);
            SecurityContextManager.Current.CurrentProfile = response.Learner;
            view.SelectedLearner = response.Learner;
            return View(view);
        }

        public ActionResult CreateLearner()
        {
            LearnerView view = new LearnerView();
            view.SideBar.SelectedMenuItem = "nav-people";
            view.SideBar.SelectedSubMenuItem = "subnav-students";
            view.SelectedLearner = new Learner();
            return View(view);
        }

        #endregion

        #region Tutors
        public ActionResult TutorList()
        {
            TutorView view = new TutorView();
            view.SideBar.SelectedMenuItem = "nav-people";
            view.SideBar.SelectedSubMenuItem = "subnav-instructors";
            view.TutorList = _tutorService.GetTutorList().Tutors.ToList<ITutor>();
            return View(view);
        }

        public ActionResult TutorProfile(int id)
        {
            TutorView view = new TutorView();
            view.SideBar.SelectedMenuItem = "nav-people";
            view.SideBar.SelectedSubMenuItem = "subnav-instructors";
            var ethnicities = from EthnicityType e in Enum.GetValues(typeof(EthnicityType))
                              select new { Value = e, Text = e.ToString().Replace("_", " ") };
            view.Ethnicities = new SelectList(ethnicities, "Value", "Text");
            var educationlevel = from EducationLevel e in Enum.GetValues(typeof(EducationLevel))
                                 select new { Value = e, Text = e.ToString().Replace("_", " ") };
            view.EducationLevels = new SelectList(educationlevel, "Value", "Text");
            GetTutorResponse response = new GetTutorResponse();
            response = _tutorService.GetTutorByID(id);
            SecurityContextManager.Current.CurrentProfile = response.Tutor;
            view.SelectedTutor = response.Tutor;
            return View(view);
        }

        public ActionResult CreateTutor()
        {
            TutorView view = new TutorView();
            view.SideBar.SelectedMenuItem = "nav-people";
            view.SideBar.SelectedSubMenuItem = "subnav-tutor";
            view.SelectedTutor = new Tutor();
            return View(view);
        }

        #endregion

    }
}
