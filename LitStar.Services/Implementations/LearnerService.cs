using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Core.Domain.User;
using LitStar.Core.Security;
using LitStar.Infrastructure.Querying;
using LitStar.Services.Interfaces;
using LitStar.Services.Messaging.LearnerService;
using LitStar.Services.Mapping;
using LitStar.Services.Cache.CacheStorage;
using LitStar.Infrastructure.UnitOfWork;

namespace LitStar.Services.Implementations
{
    public class LearnerService : ILearnerService
    {
        private readonly ILearnerRepository _repository;
        private readonly ICacheStorage _cache;
        private readonly IUnitOfWork _uow;

        public LearnerService(ILearnerRepository repository, ICacheStorage cache, IUnitOfWork uow)
        {
            _repository = repository;
            _cache = cache;
            _uow = uow;
        }

        public GetLearnerListResponse GetLearnerList()
        {
            GetLearnerListResponse response = new GetLearnerListResponse();
            var list = _repository.FindAll();
            if (list != null && list.Count() > 0)
                response.Learners = list.ToList<ILearner>();
            return response;
        }

        public GetLearnerResponse GetLearnerByEmail(GetLearnerByEmailRequest request)
        {
            var query = new Query();
            query.Add(new Criterion("Email", request.Email, CriteriaOperator.Equal));
            GetLearnerResponse response = new GetLearnerResponse();
            var learner = _repository.FindBy(query);
            if (learner != null)
                response.Learner = learner.FirstOrDefault<ILearner>();
            return response;
        }

        public GetLearnerResponse GetLearnerByID(int id)
        {
            var query = new Query();
            query.Add(new Criterion("ID", id, CriteriaOperator.Equal));
            GetLearnerResponse response = new GetLearnerResponse();
            var learner = _repository.FindBy(query);
            if (learner != null)
                response.Learner = learner.FirstOrDefault<ILearner>();
            return response;
        }

        public CreateLearnerResponse CreateLearner(CreateLearnerRequest request)
        {
            var response = new CreateLearnerResponse();
            _repository.Save((Learner)request.Learner);
            _uow.Commit();
            response.View.Learner = request.Learner;
            return response;
        }

        public UpdateLearnerResponse UpdateLearner(UpdateLearnerRequest request)
        {
            var response = new UpdateLearnerResponse();
            _repository.Save((Learner)request.Learner);
            _uow.Commit();
            response.View.Learner = request.Learner;
            response.Success = true;
            response.Message = "Learner Saved Successfully";
            return response;
        }
    }
}
