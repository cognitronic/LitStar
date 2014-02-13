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
    public class LearningSessionAvailabilityMap : ClassMap<LearningSessionAvailability>
    {
        public LearningSessionAvailabilityMap()
        {
            Id(x => x.ID);
            Map(x => x.DayOfWeek);
            Map(x => x.EndTime);
            Map(x => x.LocationID);
            Map(x => x.StartTime);
            Map(x => x.UserID);
        }
    }
}
