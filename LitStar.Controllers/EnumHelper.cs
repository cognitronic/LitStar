using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Core.Domain.User;
using System.Web.Mvc;
using System.Web;

namespace LitStar.Controllers
{
    public static class EnumHelper
    {
        public static SelectList ToSelectList<T>(this T enumObj)
        {
            var values = from T e in Enum.GetValues(typeof(T))
                         select new { ID = e, Name = e.ToString() };

            return new SelectList(values, "ID", "Name", enumObj);
        }
    }
}
