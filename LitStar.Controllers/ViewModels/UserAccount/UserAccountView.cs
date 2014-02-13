﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LitStar.Infrastructure.Authentication;

namespace LitStar.Controllers.ViewModels.UserAccount
{
    public class UserAccountView : IBaseView, LitStar.Infrastructure.Authentication.IUserAccount
    {
        public UserAccountView()
        {
            CallBackSettings = new CallBackSettings();
            SideBar = new SideBarView();
            TopNavBar = new TopNavBarView();
            
        }

        public CallBackSettings CallBackSettings{ get; set; }
        public bool HasIssue { get; set; }
        public string Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public string AuthenticationToken { get; set; }
        public SideBarView SideBar { get; set; }
        public TopNavBarView TopNavBar { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Type { get; set; }

        [Required]
        [Display(Name = "Username (email address)")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        
    }
}
