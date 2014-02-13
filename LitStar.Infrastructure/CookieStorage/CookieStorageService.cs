using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LitStar.Infrastructure.CookieStorage
{
    public class CookieStorageService : ICookieStorageService
    {

        #region ICookieStorageService Members

        public void Save(string key, string value, DateTime expires)
        {
            HttpContext.Current.Response.Cookies[key].Value = value;
            HttpContext.Current.Response.Cookies[key].Expires = expires;
        }

        public string Retrieve(string key)
        {
            HttpCookie cookie = HttpContext.Current.Response.Cookies[key];
            if (cookie != null)
                return cookie.Value;
            return "";
        }

        #endregion
    }
}
