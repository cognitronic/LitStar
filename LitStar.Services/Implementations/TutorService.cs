using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Core.Domain.User;
using LitStar.Core.Security;
using LitStar.Infrastructure.Querying;
using LitStar.Services.Interfaces;
using LitStar.Services.Messaging.TutorService;
using LitStar.Services.Mapping;
using LitStar.Services.Cache.CacheStorage;
using LitStar.Infrastructure.UnitOfWork;

namespace LitStar.Services.Implementations
{
    public class TutorService : ITutorService
    {
        private readonly ITutorRepository _repository;
        private readonly ICacheStorage _cache;
        private readonly IUnitOfWork _uow;

        public TutorService(ITutorRepository repository, ICacheStorage cache, IUnitOfWork uow)
        {
            _repository = repository;
            _cache = cache;
            _uow = uow;
        }

        public GetTutorListResponse GetTutorList()
        {
            GetTutorListResponse response = new GetTutorListResponse();
            var list = _repository.FindAll();
            if (list != null && list.Count() > 0)
                response.Tutors = list.ToList<ITutor>();
            return response;
        }

        public GetTutorResponse GetTutorByEmail(GetTutorByEmailRequest request)
        {
            var query = new Query();
            query.Add(new Criterion("Email", request.Email, CriteriaOperator.Equal));
            GetTutorResponse response = new GetTutorResponse();
            var Tutor = _repository.FindBy(query);
            if (Tutor != null)
                response.Tutor = Tutor.FirstOrDefault<ITutor>();
            return response;
        }

        public GetTutorResponse GetTutorByID(int id)
        {
            var query = new Query();
            query.Add(new Criterion("ID", id, CriteriaOperator.Equal));
            GetTutorResponse response = new GetTutorResponse();
            var Tutor = _repository.FindBy(query);
            if (Tutor != null)
                response.Tutor = Tutor.FirstOrDefault<ITutor>();
            return response;
        }

        public CreateTutorResponse CreateTutor(CreateTutorRequest request)
        {
            var response = new CreateTutorResponse();
            _repository.Save((Tutor)request.Tutor);
            _uow.Commit();
            response.View.Tutor = request.Tutor;
            return response;
        }

        public UpdateTutorResponse UpdateTutor(UpdateTutorRequest request)
        {
            var response = new UpdateTutorResponse();
            _repository.Save((Tutor)request.Tutor);
            _uow.Commit();
            response.View.Tutor = request.Tutor;
            response.Success = true;
            response.Message = "Tutor Saved Successfully";
            return response;
        }
    }
}
