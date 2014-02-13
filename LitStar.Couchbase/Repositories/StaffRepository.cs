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
    public class StaffRepository : BaseRepository<Staff, string>, IUnitOfWorkRepository, IStaffRepository
    {
        public StaffRepository(IUnitOfWork uow) : base(uow) { }


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

        public IList<IStaff> GetByAccount(string accountid)
        {
            return _Client.GetView<Staff>("litstar", "user_by_accountID", true).Stale(StaleMode.False).Key(accountid).ToList<IStaff>();
        }

        public IList<IStaff> GetByActivationStatus(bool isActive)
        {
            return _Client.GetView<Staff>("litstar", "user_by_isActive", true).Stale(StaleMode.False).Key(isActive).ToList<IStaff>();
        }

        public IList<IStaff> GetAll()
        {
            return _Client.GetView<Staff>("litstar", "user_by_type", true).Stale(StaleMode.False).Key("Staff").ToList<IStaff>();
        }

        public IStaff GetByEmail(string email)
        {
            return _Client.GetView<Staff>("litstar", "user_accounts_by_email", true).Stale(StaleMode.False).Key(email).FirstOrDefault<IStaff>();
        }
    }

}
