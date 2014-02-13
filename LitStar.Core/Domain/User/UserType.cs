using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace LitStar.Core.Domain.User
{
    [Serializable]
    public enum UserType
    {
        Staff = 1,
        Learner = 2,
        Tutor = 3,
        Donor = 4,
        User = 5
    }
}
