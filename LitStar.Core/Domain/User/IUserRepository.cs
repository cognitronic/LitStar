using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Infrastructure.Domain;

namespace LitStar.Core.Domain.User
{
    public interface IUserRepository : IRepository<User>
    {
        User FindBy(int ID);
    }
}