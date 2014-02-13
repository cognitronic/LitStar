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
    public class UserLanguage
    {
        [DataMember]
        public int UserID { get; set; }

        [DataMember]
        public int LanguageID { get; set; }
    }
}
