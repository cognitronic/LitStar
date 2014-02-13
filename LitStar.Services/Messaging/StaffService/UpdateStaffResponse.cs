using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Core.Domain.User;
using LitStar.Services.ViewModels;

namespace LitStar.Services.Messaging.StaffService
{
    public class UpdateStaffResponse : Response
    {
        public UpdateStaffResponse()
        {
            View = new StaffView();
        }
        public StaffView View { get; set; }
    }
}
