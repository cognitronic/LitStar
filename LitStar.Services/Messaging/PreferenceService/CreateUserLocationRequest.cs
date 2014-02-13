using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Core.Domain.Preference;

namespace LitStar.Services.Messaging.PreferenceService
{
    public class CreateUserLocationRequest
    {
        public IUserLocation UserLocation { get; set; }
    }
}
