using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Core.Domain.User;

namespace LitStar.Services.Messaging.StaffService
{
    public class CreateStaffRequest
    {
        public IStaff Staff { get; set; }
    }
}
