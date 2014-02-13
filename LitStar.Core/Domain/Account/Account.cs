using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Infrastructure.Domain;
using System.Runtime.Serialization;

namespace LitStar.Core.Domain.Account
{
    [Serializable]
    public class Account : EntityBase, IAccount, IAggregateRoot
    {
        #region IAccount Members
        [DataMember]
        public virtual string Name { get; set; }
        [DataMember]
        public virtual int AccountTypeID { get; set; }
        [DataMember]
        public virtual AccountType AccountType { get; set; }
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
        public virtual string Phone { get; set; }
        [DataMember]
        public virtual string Fax { get; set; }
        [DataMember]
        public virtual string Email { get; set; }
        [DataMember]
        public virtual string Website { get; set; }

        #endregion

        #region ISystemObject Members
        [DataMember]
        public virtual int ID { get; set; }
        [DataMember]
        public virtual Guid SystemID { get; set; }
        [DataMember]
        public virtual string Type { get; set; }

        #endregion

        public Account()
        {

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
    }
}
