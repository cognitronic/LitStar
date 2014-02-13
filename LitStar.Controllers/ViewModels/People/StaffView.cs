using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Controllers.ViewModels;
using LitStar.Core.Domain.User;

namespace LitStar.Controllers.ViewModels.People
{
    public class StaffView : IBaseView
    {
        public StaffView()
        {
            SideBar = new SideBarView();
            TopNavBar = new TopNavBarView();
            Managers = new ManagersDDLView();
            AccessLevels = new AccessLevelDDLView();
        }
        public IList<IStaff> StaffList { get; set; }
        public IStaff SelectedStaff { get; set; }
        public SideBarView SideBar { get; set; }
        public TopNavBarView TopNavBar { get; set; }
        public ManagersDDLView Managers { get; set; }
        public AccessLevelDDLView AccessLevels { get; set; }
    }
}
