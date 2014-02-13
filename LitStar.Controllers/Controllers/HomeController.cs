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
using EO.Pdf;

namespace LitStar.Controllers.Controllers
{
    
    public class HomeController : BaseUserAccountController
    {
        public HomeController(ILocalAuthenticationService authenticationService,
            IUserService userService,
            IExternalAuthenticationService externalAuthenticationService,
            IFormsAuthentication formsAuthentication,
            IActionArguments actionArguments)
            : base(authenticationService, userService, externalAuthenticationService, formsAuthentication, actionArguments)
        {
            SecurityContextManager.Current.CurrentProfile = null;
        }

        [LitStarAuthorize]
        public ActionResult Index()
        {
            UserAccountView view = new UserAccountView();
            view.SideBar.SelectedMenuItem = "nav-dashboard";
            view.Message = "It's Working!!!";
            view.CallBackSettings.ReturnUrl = "nav-dashboard";
            return View(view);

        }

        [AllowAnonymous]
        public ActionResult PrintPdf()
        {
            using (HtmlToPdfSession session = HtmlToPdfSession.Create())
            {
                session.LoadUrl("https://beta.hrriver.com/Login");
                session.Fill("tbUsername", "jet@hrriver.com");
                session.Fill("tbUsername_ClientState", "{\"enabled\":true,\"emptyMessage\":\"\",\"validationText\":\"danny@hrriver.com\",\"valueAsString\":\"danny@hrriver.com\"}");
                session.Fill("tbPassword", "changeme");
                session.Fill("tbPassword_ClientState", "{\"enabled\":true,\"emptyMessage\":\"\",\"validationText\":\"changeme\",\"valueAsString\":\"changeme\"}");

                session.Submit("lbLogin");
                session.LoadUrl("https://beta.hrriver.com/comments/all");
                try
                {
                    session.RenderAsPDF("d:\\comments.pdf");
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                }
            }
            return View();
        }
    }
}
