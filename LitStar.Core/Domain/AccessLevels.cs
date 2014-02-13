using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitStar.Core.Domain
{
    public enum AccessLevels
    {
        Admin = 60,
        Manager = 30,
        Staff = 15,
        Tutor = 10,
        Learner = 5,
        None = 0
    }
}
