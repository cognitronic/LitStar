using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace LitStar.Infrastructure.Authentication
{
    public class AspMembershipAuthentication : ILocalAuthenticationService
    {
        //public IUserAccount Login(string email, string password)
        //{
        //    IUserAccount user = new IUserAccount();
        //    user.IsAuthenticated = false;

        //    if (Membership.ValidateUser(email, password))
        //    {
        //        System.Web.Security.MembershipUser validatedUser = Membership.GetUser(email);
        //        user.AuthenticationToken = validatedUser.ProviderUserKey.ToString();
        //        user.Email = email;
        //        user.IsAuthenticated = true;
        //    }
        //    return user;
        //}

        //public IUserAccount RegisterUser(string email, string password)
        //{
        //    MembershipCreateStatus status;
        //    IUserAccount user = new IUserAccount();
        //    user.IsAuthenticated = false;

        //    Membership.CreateUser(email, password, email, Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), true, out status);
        //    if (status == MembershipCreateStatus.Success)
        //    {
        //        MembershipUser newlyCreatedUser = Membership.GetUser(email);
        //        user.AuthenticationToken = newlyCreatedUser.ProviderUserKey.ToString();
        //        user.Email = email;
        //        user.IsAuthenticated = true;
        //    }
        //    else
        //    {
        //        switch (status)
        //        {
        //            case MembershipCreateStatus.DuplicateUserName:
        //            case MembershipCreateStatus.DuplicateEmail:
        //                throw new InvalidOperationException("There is already a user with this email address.");
        //            case MembershipCreateStatus.InvalidEmail:
        //                throw new InvalidOperationException("Your email address is invalid.");
        //            default:
        //                throw new InvalidOperationException("There was a problem creating your account.  Please try again.");

        //        }
        //    }
        //    return user;
        //}
        #region ILocalAuthenticationService Members

        public IUserAccount Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public IUserAccount RegisterUser(string email, string password)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
