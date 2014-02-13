using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Controllers.ViewModels.UserAccount;
using LitStar.Core.Domain.User;
using LitStar.Services.ViewModels;
using LitStar.Infrastructure.Authentication;
using AutoMapper;
using System.Runtime.Serialization;

namespace LitStar.Controllers
{
    [Serializable]
    public class AutoMapperBootStrapper
    {
        public static void ConfigureAutoMapper()
        {
            Mapper.CreateMap<IUserAccount, User>();
        }
    }
}
