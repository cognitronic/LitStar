﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitStar.Infrastructure.Authentication
{
    public interface IUserAccount
    {
        string AuthenticationToken { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        bool IsAuthenticated { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Type { get; set; }
    }
}