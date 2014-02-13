using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitStar.Core.Security
{
    public class SecurityContextManager
    {
        private static ILitStarSecurityContext _securityContext;

        private SecurityContextManager() { }

        public static ILitStarSecurityContext Current
        {
            get
            {
                return _securityContext;
            }
            set
            {
                _securityContext = value;
            }
        }
    }
}
