using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Core.Domain.User;

namespace LitStar.Services.Messaging.UserService
{
    public class GetValidUserResponse
    {
        public IUser SelectedUser { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
