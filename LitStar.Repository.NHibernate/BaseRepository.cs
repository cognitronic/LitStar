using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Infrastructure.Domain;
using LitStar.Infrastructure.Querying;
using LitStar.Infrastructure.UnitOfWork;
using LitStar.Repository.NHibernate.SessionStorage;
using NHibernate;

namespace LitStar.Repository.NHibernate
{
    public abstract class BaseRepository<T, TEntityKey> : IUnitOfWorkRepository, IRepository<T> where T : ISystemObject,IAggregateRoot
    {
        private IUnitOfWork _uow;

        public BaseRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Add(T entity)
        {
            _uow.RegisterNew(entity, this);
        }

        public void Remove(T entity)
        {
            _uow.RegisterRemoved(entity, this);
        }

        public void Save(T entity)
        {
            _uow.RegisterAmended(entity, this);
        }

        public T FindBy(TEntityKey id)
        {
            return SessionFactory.GetCurrentSession().Get<T>(id);
        }

        public IList<T> FindAll()
        {
            ICriteria criteriaQuery = SessionFactory.GetCurrentSession().CreateCriteria(typeof(T));
            return (List<T>)criteriaQuery.List<T>();
        }

        public IList<T> FindAll(int index, int count)
        {
            ICriteria criteriaQuery = SessionFactory.GetCurrentSession().CreateCriteria(typeof(T));
            return (List<T>)criteriaQuery.SetFetchSize(count).SetFirstResult(index).List<T>();
        }

        public IList<T> FindBy(Query query)
        {
            ICriteria criteriaQuery = SessionFactory.GetCurrentSession().CreateCriteria(typeof(T));

            AppendCriteria(criteriaQuery);

            query.TranslateIntoNHQuery<T>(criteriaQuery);
            return criteriaQuery.List<T>();
        }

        public IList<T> FindBy(Query query, int index, int count)
        {
            ICriteria criteriaQuery = SessionFactory.GetCurrentSession().CreateCriteria(typeof(T));

            AppendCriteria(criteriaQuery);

            query.TranslateIntoNHQuery<T>(criteriaQuery);
            return criteriaQuery.SetFetchSize(count).SetFirstResult(index).List<T>();
        }

        public virtual void AppendCriteria(ICriteria criteria)
        { 
            
        }

        #region IUnitOfWorkRepository Members

        public void PersistCreationOf(IAggregateRoot entity)
        {
            SessionFactory.GetCurrentSession().Save(entity);
        }

        public void PersistUpdateOf(IAggregateRoot entity)
        {
            SessionFactory.GetCurrentSession().SaveOrUpdate(entity);
        }

        public void PersistDeletionOf(IAggregateRoot entity)
        {
            SessionFactory.GetCurrentSession().Delete(entity);
        }

        #endregion
    }
}
