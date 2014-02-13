using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Services.Messaging.PreferenceService;

namespace LitStar.Services.Interfaces
{
    public interface IPreferenceService
    {
        GetLanguageListResponse GetLanguageList();
        GetLanguageResponse GetLanguageByID(int ID);
        CreateLanguageResponse CreateLanguage(CreateLanguageRequest request);
        UpdateLanguageResponse UpdateLanguage(UpdateLanguageRequest request);

        GetLearningSessionAvailabilityListResponse GetLearningSessionAvailabilityList();
        GetLearningSessionAvailabilityResponse GetLearningSessionAvailabilityByID(int ID);
        CreateLearningSessionAvailabilityResponse CreateLearningSessionAvailability(CreateLearningSessionAvailabilityRequest request);
        UpdateLearningSessionAvailabilityResponse UpdateLearningSessionAvailability(UpdateLearningSessionAvailabilityRequest request);


        GetLocationListResponse GetLocationList();
        GetLocationResponse GetLocationByID(int ID);
        CreateLocationResponse CreateLocation(CreateLocationRequest request);
        UpdateLocationResponse UpdateLocation(UpdateLocationRequest request);


        GetUserLanguageListResponse GetUserLanguageList();
        GetUserLanguageResponse GetUserLanguageByID(int ID);
        CreateUserLanguageResponse CreateUserLanguage(CreateUserLanguageRequest request);
        UpdateUserLanguageResponse UpdateUserLanguage(UpdateUserLanguageRequest request);

        GetUserLocationListResponse GetUserLocationList();
        GetUserLocationResponse GetUserLocationByID(int ID);
        CreateUserLocationResponse CreateUserLocation(CreateUserLocationRequest request);
        UpdateUserLocationResponse UpdateUserLocation(UpdateUserLocationRequest request);

        GetUserPreferenceListResponse GetUserPreferenceList();
        GetUserPreferenceResponse GetUserPreferenceByID(int ID);
        CreateUserPreferenceResponse CreateUserPreference(CreateUserPreferenceRequest request);
        UpdateUserPreferenceResponse UpdateUserPreference(UpdateUserPreferenceRequest request);
    }
}
