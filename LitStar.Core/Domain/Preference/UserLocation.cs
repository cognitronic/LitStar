using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Infrastructure.Domain;
using System.Runtime.Serialization;
using LitStar.Core.Domain.Account;

namespace LitStar.Core.Domain.Preference
{
    [Serializable]
    public class UserLocation : EntityBase, IUserLocation, IAggregateRoot
    {
        [DataMember]
        public virtual int UserID { get; set; }

        [DataMember]
        public virtual int LocationID { get; set; }

        [DataMember]
        public virtual int ID { get; set; }

        [DataMember]
        public virtual Guid SystemID { get; set; }

        [DataMember]
        public virtual string Type { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
