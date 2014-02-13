using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Core.Domain.User;
using LitStar.Services.ViewModels;
using AutoMapper;

namespace LitStar.Services
{
    public class AutoMapperBootStrapper
    {
        public static void ConfigureAutoMapper()
        { 
            //Users
            Mapper.CreateMap<IUser, UserView>();
            
        }


    }
}
