using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using LitStar.Infrastructure.Domain;

namespace LitStar.Infrastructure.Authentication
{
    public class CustomMembershipUser : MembershipUser
    {
        private IBaseUser _baseUser;
        private int _accountID;

        public IBaseUser BaseUser
        {
            get
            {
                return _baseUser;
            }
            set
            {
                _baseUser = value;
            }
        }

        public int AccountID
        {
            get
            {
                return _accountID;
            }
            set
            {
                _accountID = value;
            }
        }

        public CustomMembershipUser(string providername,
                                  string username,
                                  object providerUserKey,
                                  string email,
                                  string passwordQuestion,
                                  string comment,
                                  bool isApproved,
                                  bool isLockedOut,
                                  DateTime creationDate,
                                  DateTime lastLoginDate,
                                  DateTime lastActivityDate,
                                  DateTime lastPasswordChangedDate,
                                  DateTime lastLockedOutDate,
                                  IBaseUser baseUser,
                                  int accountID) :
            base(providername,
                                       username,
                                       providerUserKey,
                                       email,
                                       passwordQuestion,
                                       comment,
                                       isApproved,
                                       isLockedOut,
                                       creationDate,
                                       lastLoginDate,
                                       lastActivityDate,
                                       lastPasswordChangedDate,
                                       lastLockedOutDate)
        {
            this.BaseUser = baseUser;
            this.AccountID = accountID;
        }
    }
}
