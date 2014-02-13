using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using LitStar.Infrastructure.Authentication;
using LitStar.Services.Interfaces;
using LitStar.Services.Messaging.UserService;
using LitStar.Services.ViewModels;
using LitStar.Core.Domain.User;
using LitStar.Infrastructure.CookieStorage;

namespace LitStar.Controllers.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IFormsAuthentication _formsAuthentication;

        public UserController(ICookieStorageService cookieStorageService, IUserService userService, IFormsAuthentication formsAuthentication) : base(cookieStorageService)
        {
            _userService = userService;
            _formsAuthentication = formsAuthentication;
        }

        //[Authorize]
        //public ActionResult Detail
    }
}
