using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Services.Messaging.StaffService;

namespace LitStar.Services.Interfaces
{
    public interface IStaffService
    {
        GetStaffListResponse GetStaffList();
        GetStaffResponse GetStaffByEmail(GetStaffByEmailRequest request);
        GetStaffResponse GetStaffByID(int ID);
        GetStaffListResponse GetManagers();
        UpdateStaffResponse UpdateStaff(UpdateStaffRequest request);
        CreateStaffResponse CreateStaff(CreateStaffRequest request);
    }
}
