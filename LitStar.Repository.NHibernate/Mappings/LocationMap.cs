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
    public class LocationMap : ClassMap<Location>
    {
        public LocationMap()
        {
            Id(x => x.ID);
            Map(x => x.Address);
            Map(x => x.City);
            Map(x => x.Latitude);
            Map(x => x.Longitude);
            Map(x => x.Name);
            Map(x => x.Phone);
            Map(x => x.State);
            Map(x => x.Zip);
        }
    }
}
