using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Core.Domain.Preference;
using LitStar.Core.Security;
using LitStar.Infrastructure.Querying;
using LitStar.Services.Interfaces;
using LitStar.Services.Messaging.PreferenceService;
using LitStar.Services.Mapping;
using LitStar.Services.Cache.CacheStorage;
using LitStar.Infrastructure.UnitOfWork;

namespace LitStar.Services.Implementations
{
    public class PreferenceService : IPreferenceService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly ILearningSessionAvailabilityRepository _learningSessionAvailabilityRepository;
        private readonly IUserLanguageRepository _userLanguageRepository;
        private readonly IUserLocationRepository _userLocationRepository;
        private readonly IUserPreferenceRepository _userPreferenceRepository;
        private readonly ICacheStorage _cache;
        private readonly IUnitOfWork _uow;

        public PreferenceService(ILocationRepository locationRepository, 
            ILanguageRepository languageRepository,
            ILearningSessionAvailabilityRepository learningSessionAvailabilityRepository,
            IUserLanguageRepository userLanguageRepository,
            IUserLocationRepository userLocationRepository,
            IUserPreferenceRepository userPreferenceRepository,
            ICacheStorage cache, 
            IUnitOfWork uow)
        {
            _locationRepository = locationRepository;
            _languageRepository = languageRepository;
            _learningSessionAvailabilityRepository = learningSessionAvailabilityRepository;
            _userLanguageRepository = userLanguageRepository;
            _userLocationRepository = userLocationRepository;
            _userPreferenceRepository = userPreferenceRepository;
            _cache = cache;
            _uow = uow;
        }

        #region Language

        public GetLanguageListResponse GetLanguageList()
        {
            throw new NotImplementedException();
        }

        public GetLanguageResponse GetLanguageByID(int ID)
        {
            throw new NotImplementedException();
        }

        public CreateLanguageResponse CreateLanguage(CreateLanguageRequest request)
        {
            throw new NotImplementedException();
        }

        public UpdateLanguageResponse UpdateLanguage(UpdateLanguageRequest request)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Learning Session Availability

        public GetLearningSessionAvailabilityListResponse GetLearningSessionAvailabilityList()
        {
            throw new NotImplementedException();
        }

        public GetLearningSessionAvailabilityResponse GetLearningSessionAvailabilityByID(int ID)
        {
            throw new NotImplementedException();
        }

        public CreateLearningSessionAvailabilityResponse CreateLearningSessionAvailability(CreateLearningSessionAvailabilityRequest request)
        {
            throw new NotImplementedException();
        }

        public UpdateLearningSessionAvailabilityResponse UpdateLearningSessionAvailability(UpdateLearningSessionAvailabilityRequest request)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Location

        public GetLocationListResponse GetLocationList()
        {
            GetLocationListResponse response = new GetLocationListResponse();
            var list = _locationRepository.FindAll();
            if (list != null && list.Count() > 0)
                response.Locations = list.ToList<ILocation>();
            return response;
        }

        public GetLocationResponse GetLocationByID(int ID)
        {
            var query = new Query();
            query.Add(new Criterion("ID", ID, CriteriaOperator.Equal));
            GetLocationResponse response = new GetLocationResponse();
            var location = _locationRepository.FindBy(query);
            if (location != null)
                response.Location = location.FirstOrDefault<ILocation>();
            return response;
        }

        public CreateLocationResponse CreateLocation(CreateLocationRequest request)
        {
            var response = new CreateLocationResponse();
            _locationRepository.Save((Location)request.Location);
            _uow.Commit();
            response.View.Location = request.Location;
            return response;
        }

        public UpdateLocationResponse UpdateLocation(UpdateLocationRequest request)
        {
            var response = new UpdateLocationResponse();
            _locationRepository.Save((Location)request.Location);
            _uow.Commit();
            response.View.Location = request.Location;
            response.Success = true;
            response.Message = "Location Saved Successfully";
            return response;
        }

        #endregion

        #region User Language

        public GetUserLanguageListResponse GetUserLanguageList()
        {
            throw new NotImplementedException();
        }

        public GetUserLanguageResponse GetUserLanguageByID(int ID)
        {
            throw new NotImplementedException();
        }

        public CreateUserLanguageResponse CreateUserLanguage(CreateUserLanguageRequest request)
        {
            throw new NotImplementedException();
        }

        public UpdateUserLanguageResponse UpdateUserLanguage(UpdateUserLanguageRequest request)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region User Location
        public GetUserLocationListResponse GetUserLocationList()
        {
            throw new NotImplementedException();
        }

        public GetUserLocationResponse GetUserLocationByID(int ID)
        {
            throw new NotImplementedException();
        }

        public CreateUserLocationResponse CreateUserLocation(CreateUserLocationRequest request)
        {
            throw new NotImplementedException();
        }

        public UpdateUserLocationResponse UpdateUserLocation(UpdateUserLocationRequest request)
        {
            throw new NotImplementedException();
        }

        #endregion 

        #region User Preference

        public GetUserPreferenceListResponse GetUserPreferenceList()
        {
            throw new NotImplementedException();
        }

        public GetUserPreferenceResponse GetUserPreferenceByID(int ID)
        {
            throw new NotImplementedException();
        }

        public CreateUserPreferenceResponse CreateUserPreference(CreateUserPreferenceRequest request)
        {
            throw new NotImplementedException();
        }

        public UpdateUserPreferenceResponse UpdateUserPreference(UpdateUserPreferenceRequest request)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
