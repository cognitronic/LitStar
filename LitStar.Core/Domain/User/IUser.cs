using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Infrastructure.Domain;
using LitStar.Infrastructure.Authentication;
using LitStar.Core.Domain.Account;

namespace LitStar.Core.Domain.User
{
    public interface IUser : IBaseUser, ISystemObject, IAuditable, IAggregateRoot
    {
        UserType UserType { get; set; }
        int AccountID { get; set; }
        IAccount Account { get; set; }
        string Password { get; set; }
        string SecurityQuestion { get; set; }
        string SecurityAnswer { get; set; }
        DateTime? LastLoggedIn { get; set; }
        int AccessLevel { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        bool IsActive { get; set; }
        string AvatarPath { get; set; }
        string Username { get; set; }
    }
}
