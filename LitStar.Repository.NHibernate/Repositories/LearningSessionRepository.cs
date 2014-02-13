using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Core.Domain.Instruction;
using LitStar.Infrastructure.Domain;
using LitStar.Infrastructure.Querying;
using LitStar.Infrastructure.UnitOfWork;

namespace LitStar.Repository.NHibernate.Repositories
{
    public class LearningSessionRepository: BaseRepository<LearningSession, int>, ILearningSessionRepository
    {
        public LearningSessionRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
