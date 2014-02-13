using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Core.Domain.User;
using LitStar.Infrastructure.Domain;

namespace LitStar.Core.Domain.Goal
{
    public interface IGoal : ISystemObject, IAuditable
    {
        DateTime DueDate { get; set; }
        DateTime DateCompleted { get; set; }
        int GoalType { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        int LearnerID { get; set; }
        string TutorEvaluation { get; set; }
        string StudenEvalutaion { get; set; }
        int GoalStatus { get; set; }
        bool IsTemplate { get; set; }
    }
}
