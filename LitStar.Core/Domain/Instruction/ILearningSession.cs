using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Infrastructure.Domain;

namespace LitStar.Core.Domain.Instruction
{
    public interface ILearningSession : ISystemObject, IAuditable
    {
        int TutorID { get; set; }
        int LearnerID { get; set; }
        int LocationID { get; set; }
        DateTime DateOfSession { get; set; }
        DateTime StartTime { get; set; }
        DateTime EndTime { get; set; }
        int PrepHours { get; set; }
        int TravelTimeInMinutes { get; set; }
        string WorkPerformed { get; set; }
        string HomeworkAssigned { get; set; }
        string TutorComments { get; set; }
        string LearnerComments { get; set; }
    }
}
