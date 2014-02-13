using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Controllers.ViewModels;
using LitStar.Core.Domain.User;
using System.Web.Mvc;
using System.Web;

namespace LitStar.Controllers.ViewModels.People
{
    public class LearnerView : IBaseView
    {
        public LearnerView()
        {
            SideBar = new SideBarView();
            TopNavBar = new TopNavBarView();
            AccessLevels = new AccessLevelDDLView();
        }
        public IList<ILearner> LearnerList { get; set; }
        public ILearner SelectedLearner { get; set; }
        public SideBarView SideBar { get; set; }
        public TopNavBarView TopNavBar { get; set; }
        public AccessLevelDDLView AccessLevels { get; set; }
        public IEnumerable<SelectListItem> Ethnicities { get; set; }
        public IEnumerable<SelectListItem> EducationLevels { get; set; }
    }
}
