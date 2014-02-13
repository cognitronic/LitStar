using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Couchbase;
using LitStar.Core.Domain.User;
using LitStar.Infrastructure.Domain;
using LitStar.Couchbase;
using LitStar.Infrastructure.UnitOfWork;
using Couchbase.Operations;

namespace LitStar.Couchbase.Repositories
{
    public class UserRepository : BaseRepository<IUser, string>, IUnitOfWorkRepository, IUserRepository
    {
        public UserRepository(IUnitOfWork uow) : base(uow) { }


        #region IUnitOfWorkRepository Members

        public void PersistCreationOf(IAggregateRoot entity)
        {

            this.Add((Staff)entity);
        }

        public void PersistUpdateOf(IAggregateRoot entity)
        {
            this.Save((Staff)entity);
        }

        public void PersistDeletionOf(IAggregateRoot entity)
        {
            this.Remove((Staff)entity);
        }

        #endregion
        public User FindByID(int ID)
        {
            return null;
        }
       
    }
}
