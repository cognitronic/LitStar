using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Infrastructure.Domain;

namespace LitStar.Core.Domain.Preference
{
    public interface ILearningSessionAvailability : ISystemObject
    {
        int UserID { get; set; }
        int LocationID { get; set; }
        int DayOfWeek { get; set; }
        DateTime StartTime { get; set; }
        DateTime EndTime { get; set; }

    }
}
