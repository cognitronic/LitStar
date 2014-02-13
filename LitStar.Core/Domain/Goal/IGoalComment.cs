using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Infrastructure.Domain;

namespace LitStar.Core.Domain.Goal
{
    public interface IGoalComment : ISystemObject
    {
        DateTime DateCreated { get; set; }
        int EnteredBy { get; set; }
        int GoalID { get; set; }
        string Comment { get; set; }
    }
}
