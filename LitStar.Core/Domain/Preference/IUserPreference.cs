using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Infrastructure.Domain;

namespace LitStar.Core.Domain.Preference
{
    public interface IUserPreference : ISystemObject
    {
        int UserID { get; set; }
        int Age { get; set; }
        bool Sex { get; set; }
        bool Smokes { get; set; }
        bool HasTutored { get; set; }
    }
}
