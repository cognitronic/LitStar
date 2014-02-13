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
    public class Tutor : EntityBase, ITutor, IAggregateRoot
    {
        #region Properties
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
        public virtual EducationLevel EducationCompleted { get; set; }

        [DataMember]
        public virtual string Occupation { get; set; }

        [DataMember]
        public virtual string ReferredBy { get; set; }

        [DataMember]
        public virtual string EmergencyContactName { get; set; }

        [DataMember]
        public virtual string EmergencyContactPhone { get; set; }

        [DataMember]
        public virtual UserType UserType { get; set; }

        [DataMember]
        public virtual int AccountID { get; set; }

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
        public virtual string Username { get; set; }

        [DataMember]
        public virtual int ID { get; set; }

        [DataMember]
        public virtual Guid SystemID { get; set; }

        [DataMember]
        public virtual string Type { get; set; }

        [DataMember]
        public virtual int EnteredBy { get; set; }

        [DataMember]
        public virtual int ChangedBy { get; set; }

        [DataMember]
        public virtual DateTime DateCreated { get; set; }

        [DataMember]
        public virtual DateTime LastUpdated { get; set; }

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

        [DataMember]
        public virtual int UserID { get; set; }

        [DataMember]
        public virtual bool IsMatched { get; set; }

        private IList<Learner> _learners = new List<Learner>();
        [DataMember]
        public virtual IList<Learner> Learners { get { return _learners; } set { _learners = value; } }

        [DataMember]
        public virtual IUser Membership { get; set; }
        #endregion

        public Tutor()
        {
            this.UserType = UserType.Tutor;
            this.Type = GetType().Name;
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
