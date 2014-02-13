using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitStar.Controllers.ViewModels
{
    public interface IBaseView
    {
        SideBarView SideBar { get; set; }
        TopNavBarView TopNavBar { get; set; }
    }
}
