using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Services.Messaging.UserService;

namespace LitStar.Services.Interfaces
{
    public interface IUserService
    {
        GetAllUsersResponse GetAllUsers();
        GetUserByEmailResponse GetUserByEmail(string email);
        CreateUserResponse CreateUser(CreateUserRequest request);
        GetUserResponse GetUser(GetUserRequest request);
        GetValidUserResponse AuthenticateUser(string email, string password);
        UpdateUserResponse UpdateUser(UpdateUserRequest request);
    }
}
