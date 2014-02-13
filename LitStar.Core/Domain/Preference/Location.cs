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
    public class Location : EntityBase, ILocation, IAggregateRoot
    {
        [DataMember]
        public virtual string Name { get; set; }

        [DataMember]
        public virtual string Address { get; set; }

        [DataMember]
        public virtual string City { get; set; }

        [DataMember]
        public virtual string State { get; set; }

        [DataMember]
        public virtual string Zip { get; set; }

        [DataMember]
        public virtual string Phone { get; set; }

        [DataMember]
        public virtual decimal Latitude { get; set; }

        [DataMember]
        public virtual decimal Longitude { get; set; }

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
