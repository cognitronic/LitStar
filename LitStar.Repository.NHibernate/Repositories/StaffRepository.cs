using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Core.Domain.User;
using LitStar.Infrastructure.Domain;
using LitStar.Infrastructure.Querying;
using LitStar.Infrastructure.UnitOfWork;

namespace LitStar.Repository.NHibernate.Repositories
{
    public class StaffRepository : BaseRepository<Staff, int>, IStaffRepository
    {
        public StaffRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
