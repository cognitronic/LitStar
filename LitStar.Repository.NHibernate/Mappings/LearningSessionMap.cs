using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using LitStar.Core.Domain.User;
using LitStar.Core.Domain.Account;
using LitStar.Core.Domain.Instruction;

namespace LitStar.Repository.NHibernate.Mappings
{
    public class LearningSessionMap : ClassMap<LearningSession>
    {
        public LearningSessionMap()
        {
            Id(x => x.ID);
            Map(x => x.ChangedBy);
            Map(x => x.DateCreated);
            Map(x => x.DateOfSession);
            Map(x => x.EndTime);
            Map(x => x.EnteredBy);
            Map(x => x.HomeworkAssigned);
            Map(x => x.LastUpdated);
            Map(x => x.LearnerComments);
            Map(x => x.LearnerID);
            Map(x => x.LocationID);
            Map(x => x.PrepHours);
            Map(x => x.StartTime);
            Map(x => x.TravelTimeInMinutes);
            Map(x => x.TutorComments);
            Map(x => x.TutorID);
            Map(x => x.WorkPerformed);
        }
    }
}
