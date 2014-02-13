using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LitStar.Core.Security;
using LitStar.Core.Domain.User;
using LitStar.Core.Domain.Account;
using LitStar.Infrastructure.Session;
using LitStar.Infrastructure.Domain;
using LitStar.Core;
using LitStar.Services.Implementations;

namespace LitStar.Web.Security
{
    [Serializable]
    public class WebSecurityContext : ILitStarSecurityContext
    {
        #region ISecurityContext Members

        public bool IsAuthenticated
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_IsAuthenticated] != null)
                {
                    return (bool)SessionManager.Current[ResourceStrings.Session_IsAuthenticated];
                }
                return false;
            }
            set
            {
                SessionManager.Current[ResourceStrings.Session_IsAuthenticated] = value;
            }
        }

        public IUser CurrentUser
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_CurrentUser] != null)
                {
                    return (User)SessionManager.Current[ResourceStrings.Session_CurrentUser];
                }
                return null;
            }
            set
            {
                SessionManager.Current[ResourceStrings.Session_CurrentUser] = value;
            }
        }

        public IUser CurrentProfile
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_CurrentProfile] != null)
                {
                    return (IUser)SessionManager.Current[ResourceStrings.Session_CurrentProfile];
                }
                return null;
            }
            set
            {
                SessionManager.Current[ResourceStrings.Session_CurrentProfile] = value;
            }
        }

        public IAccount CurrentAccount
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_CurrentAccount] != null)
                {
                    return (IAccount)SessionManager.Current[ResourceStrings.Session_CurrentAccount];
                }
                return null;
            }
            set
            {
                SessionManager.Current[ResourceStrings.Session_CurrentAccount] = value;
            }
        }

        public string BaseURL
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_CurrentBaseURL] != null)
                {
                    return SessionManager.Current[ResourceStrings.Session_CurrentBaseURL].ToString();
                }
                else
                {
                    SessionManager.Current[ResourceStrings.Session_CurrentBaseURL] = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
                    return SessionManager.Current[ResourceStrings.Session_CurrentBaseURL].ToString();
                }
            }
            set
            {
                SessionManager.Current[ResourceStrings.Session_CurrentBaseURL] = value;
            }
        }

        #endregion
    }
}