using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Core.Domain.Preference;

namespace LitStar.Services.ViewModels
{
    public class PreferenceView
    {
        public ILanguage Language { get; set; }
        public ILearningSessionAvailability LearningSessionAvailability { get; set; }
        public ILocation Location { get; set; }
        public IUserLanguage UserLanguage { get; set; }
        public IUserLocation UserLocation { get; set; }
        public IUserPreference UserPreference { get; set; }
    }
}
