using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Services.ViewModels;

namespace LitStar.Services.Messaging.UserService
{
    public class GetUserResponse
    {
        public bool UserFound { get; set; }
        public UserView User { get; set; }
    }
}
