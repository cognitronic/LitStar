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
    public class UserLocationMap : ClassMap<UserLocation>
    {
        public UserLocationMap()
        {
            Id(x => x.ID);
            Map(x => x.LocationID);
            Map(x => x.UserID);
        }
    }
}
