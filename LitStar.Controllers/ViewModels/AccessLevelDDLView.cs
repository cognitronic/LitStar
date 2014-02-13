using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Core.Domain;
using System.Web.Mvc;
using System.Web;

namespace LitStar.Controllers.ViewModels
{
    public class AccessLevelDDLView
    {
        public IList<SelectListItem> List { get; set; }

        public AccessLevelDDLView()
        {
            List = new List<SelectListItem>();
            GetDirectionSelectList();
        }

        private void GetDirectionSelectList()
        {
            Array values = Enum.GetValues(typeof(AccessLevels));
            foreach (var i in values)
            {
                List.Add(new SelectListItem
                {
                    Text = Enum.GetName(typeof(AccessLevels), i),
                    Value = ((int)i).ToString()
                });
            }
        }
    }
}
