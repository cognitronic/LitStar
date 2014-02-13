using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Services.Interfaces;
using System.Web.Mvc;
using System.Web;
using LitStar.Infrastructure.Querying;

namespace LitStar.Controllers.ViewModels
{
    public class ManagersDDLView
    {
        public IEnumerable<SelectListItem> List { get; set; }
        //IStaffService _service;
        //public ManagersDDLView(IStaffService service)
        //{
        //    _service = service;
        //    var items = new List<SelectListItem>();
        //    foreach (var item in _service.GetManagers().Staff)
        //    {
        //        items.Add(new SelectListItem { Text = item.FirstName + " " + item.LastName, Value = item.ID.ToString() });
        //    }
        //}
    }
}
