using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitStar.Core.Domain.User
{
    public static class UserFactory
    {
        public static IUser CreateConcreteUser(IUser user)
        {
            switch (user.UserType)
            { 
                case UserType.Learner:
                    return new Learner();
                case UserType.Staff:
                    return new Staff();
            }
            return null;
        }
    }
}
