using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Core.Domain.User;
using LitStar.Services.ViewModels;

namespace LitStar.Services.Messaging.PreferenceService
{
    public class CreateLearningSessionAvailabilityResponse : Response
    {
        public CreateLearningSessionAvailabilityResponse()
        {
            View = new PreferenceView();
        }
        public PreferenceView View { get; set; }
    }
}
