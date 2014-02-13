using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Core.Domain.User;

namespace LitStar.Services.Messaging.UserService
{
    public class UpdateUserRequest
    {
        public IUser User { get; set; }
    }
}
