using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Core.Domain.User;
using LitStar.Services.ViewModels;
using AutoMapper;

namespace LitStar.Services.Mapping
{
    public static class UserMapper
    {
        public static UserView ConvertToUserView(this IUser user)
        {
            return Mapper.Map<IUser, UserView>(user);
        }
    }
}
