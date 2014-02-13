using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Infrastructure.Domain;

namespace LitStar.Core.Domain.User
{
    public interface IStaffRepository : IRepository<Staff>
    {
        //IList<IStaff> GetByAccount(string accountid);
        //IList<IStaff> GetManagers();
        //IStaff GetByEmail(string email);
        //IStaff GetByUserID(int userid);
    }
}
