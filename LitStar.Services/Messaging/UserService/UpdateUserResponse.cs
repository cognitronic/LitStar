using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Core.Domain.User;
using LitStar.Services.ViewModels;

namespace LitStar.Services.Messaging.UserService
{
    public class UpdateUserResponse : Response
    {
        public UpdateUserResponse()
        {
            View = new UserView();
        }
        public UserView View { get; set; }
    }
}
