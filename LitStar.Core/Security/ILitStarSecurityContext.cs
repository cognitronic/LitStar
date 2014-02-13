using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Core.Domain.Account;
using LitStar.Infrastructure.Authentication;
using LitStar.Core.Domain.User;

namespace LitStar.Core.Security
{
    public interface ILitStarSecurityContext
    {
        IAccount CurrentAccount { get; set; }
        bool IsAuthenticated { get; set; }
        IUser CurrentUser { get; set; }
        IUser CurrentProfile { get; set; }
        string BaseURL { get; set; }
    }
}
