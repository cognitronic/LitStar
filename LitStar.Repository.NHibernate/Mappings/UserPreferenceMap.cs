using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using LitStar.Core.Domain.Preference;
using LitStar.Core.Domain.Account;

namespace LitStar.Repository.NHibernate.Mappings
{
    public class UserPreferenceMap : ClassMap<UserPreference>
    {
        public UserPreferenceMap()
        {
            Id(x => x.ID);
            Map(x => x.Age);
            Map(x => x.HasTutored);
            Map(x => x.Sex);
            Map(x => x.Smokes);
            Map(x => x.UserID);
        }
    }
}
