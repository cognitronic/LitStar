using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitStar.Services.Implementations
{
    public class UserInvalidException : Exception
    {
        public UserInvalidException(string message)
            : base(message)
        { }
    }
}
