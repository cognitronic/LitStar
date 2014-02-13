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
    public class Language : EntityBase, ILanguage, IAggregateRoot
    {
        protected override void Validate()
        {
            throw new NotImplementedException();
        }

        [DataMember]
        public virtual string Name { get; set; }

        [DataMember]
        public virtual int ID { get; set; }

        [DataMember]
        public virtual Guid SystemID { get; set; }

        [DataMember]
        public virtual string Type { get; set; }
    }
}
