using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Infrastructure.Authentication;
using LitStar.Core.Domain.User;

namespace LitStar.Services.ViewModels
{
    public class UserView : IUserAccount
    {
        public string ID { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AuthenticationToken { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public string AvatarPath { get; set; }
        public IUser UserRef { get; set; }
    }
}
