using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.WebHost;
using System.Web.SessionState;
using System.Web;
using System.Web.Routing;

namespace LitStar.Web.Routing
{
    public class LitStarHttpControllerRouteHandler : HttpControllerRouteHandler
    {
        protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new LitStarHttpControllerHandler(requestContext.RouteData);
        }
    }
}
