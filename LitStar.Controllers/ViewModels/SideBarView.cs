using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitStar.Controllers.ViewModels
{
    public class SideBarView
    {
        public string SelectedMenuItem { get; set; }
        public string SelectedSubMenuItem { get; set; }
        public string SelectedSideBar { get; set; }
        public string ProfileImagePath { get; set; }
        public string SelectedProfileName { get; set; }
        public string SelectedProfileTitle { get; set; }
    }
}
