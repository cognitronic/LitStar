using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Core.Domain.Instruction;
using LitStar.Core.Security;
using LitStar.Infrastructure.Querying;
using LitStar.Services.Interfaces;
using LitStar.Services.Messaging.InstructionService;
using LitStar.Services.Mapping;
using LitStar.Services.Cache.CacheStorage;
using LitStar.Infrastructure.UnitOfWork;

namespace LitStar.Services.Implementations
{
    public class InstructionService : IInstructionService
    {
        private readonly ILearningSessionRepository _repository;
        private readonly ICacheStorage _cache;
        private readonly IUnitOfWork _uow;

        public InstructionService(ILearningSessionRepository repository, ICacheStorage cache, IUnitOfWork uow)
        {
            _repository = repository;
            _cache = cache;
            _uow = uow;
        }

        public GetLearningSessionListResponse GetLearningSessionList()
        {
            GetLearningSessionListResponse response = new GetLearningSessionListResponse();
            var list = _repository.FindAll();
            if (list != null && list.Count() > 0)
                response.LearningSessions = list.ToList<ILearningSession>();
            return response;
        }

        public GetLearningSessionResponse GetLearningSessionByID(int ID)
        {
            var query = new Query();
            query.Add(new Criterion("ID", ID, CriteriaOperator.Equal));
            GetLearningSessionResponse response = new GetLearningSessionResponse();
            var LearningSession = _repository.FindBy(query);
            if (LearningSession != null)
                response.LearningSession = LearningSession.FirstOrDefault<ILearningSession>();
            return response;
        }

        public CreateLearningSessionResponse CreateLearningSession(CreateLearningSessionRequest request)
        {
            var response = new CreateLearningSessionResponse();
            _repository.Save((LearningSession)request.LearningSession);
            _uow.Commit();
            response.View.LearningSession = request.LearningSession;
            return response;
        }

        public UpdateLearningSessionResponse UpdateLearningSession(UpdateLearningSessionRequest request)
        {
            var response = new UpdateLearningSessionResponse();
            _repository.Save((LearningSession)request.LearningSession);
            _uow.Commit();
            response.View.LearningSession = request.LearningSession;
            response.Success = true;
            response.Message = "Learning Session Saved Successfully";
            return response;
        }
    }
}
