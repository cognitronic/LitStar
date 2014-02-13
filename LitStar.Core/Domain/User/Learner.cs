using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Infrastructure.Domain;
using System.Runtime.Serialization;

namespace LitStar.Core.Domain.User
{
    [Serializable]
    public class Learner : EntityBase, ILearner, IAggregateRoot
    {
        #region ILearnerAccount Members

        [DataMember]
        public virtual string Phone { get; set; }

        [DataMember]
        public virtual bool Sex { get; set; }

        [DataMember]
        public virtual DateTime Birthdate { get; set; }

        [DataMember]
        public virtual EthnicityType Ethnicity { get; set; }

        [DataMember]
        public virtual bool IsBillingual { get; set; }

        [DataMember]
        public virtual bool IsCitizen { get; set; }

        [DataMember]
        public virtual bool HasChildren { get; set; }

        [DataMember]
        public virtual EducationLevel EducationCompleted { get; set; }

        [DataMember]
        public virtual string Occupation { get; set; }

        [DataMember]
        public virtual string ReferredBy { get; set; }

        [DataMember]
        public virtual string Employer { get; set; }

        [DataMember]
        public virtual string EmergencyContactName { get; set; }

        [DataMember]
        public virtual string EmergencyContactPhone { get; set; }

        [DataMember]
        public virtual string PlaceOfBirth { get; set; }

        [DataMember]
        public virtual string ReasonForTutoring { get; set; }

        [DataMember]
        public virtual bool IsMatched { get; set; }

        #endregion

        //#region IAccount Members

        //public string FirstName { get; set; }

        //public string LastName { get; set; }

        //public string Email { get; set; }

        //public UserType UserType { get; set; }

        //public int AccountID { get; set; }

        //public string Password { get; set; }

        //public string SecurityQuestion { get; set; }

        //public string SecurityAnswer { get; set; }

        //public DateTime? LastLoggedIn { get; set; }

        //public bool IsActive { get; set; }

        //public bool IsAuthenticated { get; set; }

        //public string AuthenticationToken { get; set; }

        //#endregion

        //#region ISystemObject Members

        //public string ID { get; set; }

        //public Guid SystemID { get; set; }

        //public string Type { get; set; }

        //#endregion

        //#region IAuditable Members

        //public Guid EnteredBy { get; set; }

        //public Guid ChangedBy { get; set; }

        //public DateTime DateCreated { get; set; }

        //public DateTime LastUpdated { get; set; }

        //#endregion

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

        public Learner()
        {
            this.UserType = UserType.Learner;
            this.Type = GetType().Name;
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }

        #region ILearner Members


        [DataMember]
        public virtual string Email { get; set; }

        [DataMember]
        public virtual string FirstName { get; set; }

        [DataMember]
        public virtual string LastName { get; set; }

        [DataMember]
        public virtual bool IsActive { get; set; }

        [DataMember]
        public virtual string AvatarPath { get; set; }

        [DataMember]
        public virtual int AccountID { get; set; }

        [DataMember]
        public virtual int UserID { get; set; }

        [DataMember]
        public virtual IUser Membership { get; set; }

        [DataMember]
        public virtual ITutor CurrentTutor { get; set; }

        #endregion

        #region IUser Members

        [DataMember]
        public virtual UserType UserType { get; set; }

        [DataMember]
        public virtual Account.IAccount Account { get; set; }

        [DataMember]
        public virtual string Password { get; set; }

        [DataMember]
        public virtual string SecurityQuestion { get; set; }

        [DataMember]
        public virtual string SecurityAnswer { get; set; }

        [DataMember]
        public virtual DateTime? LastLoggedIn { get; set; }

        [DataMember]
        public virtual int AccessLevel { get; set; }

        #endregion

        #region IBaseUser Members

        [DataMember]
        public virtual string Username { get; set; }

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
    }
}
