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
    public class Staff : EntityBase, IStaff, IAggregateRoot
    {
        #region IStaffAccount Members
        [DataMember]
        public virtual string Title { get; set; }
        [DataMember]
        public virtual string Phone { get; set; }
        [DataMember]
        public virtual DateTime Birthdate { get; set; }
        [DataMember]
        public virtual DateTime HireDate { get; set; }
        [DataMember]
        public virtual int ManagerID { get; set; }
        [DataMember]
        public virtual decimal PayRate { get; set; }
        [DataMember]
        public virtual PayFrequency PayFrequency { get; set; }
        [DataMember]
        public virtual int UserID { get; set; }
        [DataMember]
        public virtual IUser Membership { get; set; }
        [DataMember]
        public virtual IStaff Manager { get; set; }
        [DataMember]
        public virtual DateTime? TerminationDate { get; set; }
        [DataMember]
        public virtual bool IsManager { get; set; }

        #endregion

        #region IHasAddress Members
        [DataMember]
        public virtual string Address1 { get; set; }
        [DataMember]
        public virtual string Address2 { get; set; }
        [DataMember]
        public virtual string City { get; set; }
        [DataMember]
        public virtual string State { get; set; }
        [DataMember]
        public virtual string Zip { get; set; }

        #endregion

        public Staff()
        {
            this.UserType = UserType.Staff;
            this.Type = UserType.Staff.ToString();

        }

        protected override void Validate()
        {
            //if (string.IsNullOrEmpty(FirstName))
            //    base.AddBrokenRule(UserBusinessRules.FirstNameRequired);
            //if (string.IsNullOrEmpty(LastName))
            //    base.AddBrokenRule(UserBusinessRules.LastNameRequired);
            //if (string.IsNullOrEmpty(Email))
            //    base.AddBrokenRule(UserBusinessRules.EmailRequired);
            //if (string.IsNullOrEmpty(ID))
            //    base.AddBrokenRule(UserBusinessRules.IdentityTokenRequired);
            
            //Add code to make sure email address is not duplicate
            //if (string.IsNullOrEmpty(FirstName))
            //    base.AddBrokenRule(UserBusinessRules.EmailUnique);
        }

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

        #region IUser Members

        [DataMember]
        public virtual UserType UserType { get; set; }

        [DataMember]
        public virtual int AccountID { get; set; }

        [DataMember]
        public virtual IAccount Account { get; set; }

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
        public virtual string AvatarPath { get; set; }

        [DataMember]
        public virtual int AccessLevel { get; set; }

        #endregion

        #region IBaseUser Members

        [DataMember]
        public virtual string Email { get; set; }

        [DataMember]
        public virtual string FirstName { get; set; }

        [DataMember]
        public virtual string LastName { get; set; }

        #endregion

        #region IBaseUser Members

        [DataMember]
        public virtual string Username { get; set; }

        #endregion
    }
}
