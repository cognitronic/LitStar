using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Infrastructure.Domain;
using System.Runtime.Serialization;
using LitStar.Core.Domain.Account;

namespace LitStar.Core.Domain.User
{
    [Serializable]
    public class User : EntityBase, IUser
    {
        #region IUser Members
        [DataMember]
        public virtual string FirstName { get; set; }

        [DataMember]
        public virtual string LastName { get; set; }

        [DataMember]
        public virtual string Email { get; set; }

        [DataMember]
        public virtual UserType UserType { get; set; }

        [DataMember]
        public virtual int AccountID { get; set; }
        
        [DataMember]
        public virtual IAccount Account { get; set; }

        [DataMember]
        public virtual int AccessLevel { get; set; }

        [DataMember]
        public virtual string AvatarPath { get; set; }

        [DataMember]
        public virtual string Password { get; set; }

        [DataMember]
        public virtual string SecurityQuestion { get; set; }

        [DataMember]
        public virtual string SecurityAnswer { get; set; }

        [DataMember]
        public virtual DateTime? LastLoggedIn { get; set; }

        [DataMember]
        public virtual bool IsActive { get; set; }

        [DataMember]
        public virtual bool IsAuthenticated { get; set; }

        [DataMember]
        public virtual string AuthenticationToken { get; set; }

        #endregion

        #region ISystemObject Members

        [DataMember]
        public virtual int ID { get; set; }

        [DataMember]
        public virtual Guid SystemID { get; set; }

        [DataMember]
        public virtual string Type { get; set; }

        #endregion

        #region IAuditable Members

        [DataMember]
        public virtual int EnteredBy { get; set; }

        [DataMember]
        public virtual int ChangedBy { get; set; }

        [DataMember]
        public virtual DateTime DateCreated { get; set; }

        [DataMember]
        public virtual DateTime LastUpdated { get; set; }

        #endregion

        public User()
        {
            this.UserType = UserType.User;
            this.Type = GetType().Name;
        }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(FirstName))
                base.AddBrokenRule(UserBusinessRules.FirstNameRequired);
            if (string.IsNullOrEmpty(LastName))
                base.AddBrokenRule(UserBusinessRules.LastNameRequired);
            if (string.IsNullOrEmpty(Email))
                base.AddBrokenRule(UserBusinessRules.EmailRequired);
            
            //Add code to make sure email address is not duplicate
            //if (string.IsNullOrEmpty(FirstName))
            //    base.AddBrokenRule(UserBusinessRules.EmailUnique);
        }

        #region IBaseUser Members

        [DataMember]
        public virtual string Username { get; set; }

        #endregion
    }
}
