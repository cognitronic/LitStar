﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Infrastructure.Domain;

namespace LitStar.Core.Domain.Preference
{
    public interface IUserLanguage : ISystemObject
    {
        int UserID { get; set; }
        int LanguageID { get; set; }
    }
}
