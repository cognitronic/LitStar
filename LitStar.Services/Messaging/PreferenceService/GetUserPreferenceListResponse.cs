﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Core.Domain.Preference;
using LitStar.Services.Messaging;

namespace LitStar.Services.Messaging.PreferenceService
{
    public class GetUserPreferenceListResponse : Response
    {
        public IList<IUserPreference> UserPreferences { get; set; }
    }
}
