using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Services.ViewModels;

namespace LitStar.Services.Messaging.UserService
{
    public class CreateUserRequest
    {
        public CreateUserRequest()
        {
            view = new UserView();
        }
        public UserView view { get; set; }
    }
}
