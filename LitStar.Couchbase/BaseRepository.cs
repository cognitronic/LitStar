using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using LitStar.Core.Domain;
using LitStar.Infrastructure.Domain;
using LitStar.Infrastructure.Querying;
using LitStar.Infrastructure.UnitOfWork;
using Couchbase.AspNet;
using Couchbase;
using Couchbase.Operations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Enyim.Caching.Memcached;
using inflector_extension.Inflector;
using Couchbase.Management;

namespace LitStar.Couchbase
{
    public abstract class BaseRepository<T, TEntityKey> : IRepository<T> where T : ISystemObject, IAggregateRoot
    {
        private IUnitOfWork _uow;
        protected static CouchbaseClient _Client { get; set; }
        private readonly string _designDoc;

        static BaseRepository()
        {
            _Client = SessionFactory.GetCurrentSession();
        }

        public BaseRepository(IUnitOfWork uow)
        {
            _uow = uow;
            _designDoc = typeof(T).Name.ToLower().InflectTo().Pluralized;
        }

        public void Add(T entity)
        {
            var result = _Client.ExecuteStore(StoreMode.Add, BuildKey(entity), serializeAndIgnoreId(entity));
            if (result.Exception != null) throw result.Exception;
            //return result.StatusCode.HasValue ? result.StatusCode.Value : 0;
        }

        public void Update(T entity)
        {
            var result = _Client.ExecuteStore(StoreMode.Replace, entity.ID.ToString(), serializeAndIgnoreId(entity));
            if (result.Exception != null) 
                throw result.Exception as System.Exception;
            //return result.StatusCode.HasValue ? result.StatusCode.Value : 0;
        }

        public void Remove(T entity)
        {
            var key = string.IsNullOrEmpty(entity.ID.ToString()) ? BuildKey(entity) : entity.ID.ToString();
            var result = _Client.ExecuteRemove(key);
            if (result.Exception != null) 
                throw result.Exception as System.Exception;
            //return result.StatusCode.HasValue ? result.StatusCode.Value : 0;
        }

        public void Save(T entity)
        {
            var key = string.IsNullOrEmpty(entity.ID.ToString()) ? BuildKey(entity) : entity.ID.ToString();
            var result = _Client.ExecuteStore(StoreMode.Set, key, serializeAndIgnoreId(entity));
            if (result.Exception != null) throw result.Exception as System.Exception;
            //return result.StatusCode.HasValue ? result.StatusCode.Value : 0;
        }

        public T FindBy(TEntityKey id)
        {
            return _Client.Get<T>(id.ToString());
        }

        public IList<T> FindAll()
        {
            return _Client.GetView<T>(_designDoc, "all", true).ToList<T>();
        }

        public IList<T> FindAll(int index, int count)
        {
            return _Client.GetView<T>(_designDoc, "all", true).ToList<T>();
        }

        public T FindBy(int ID)
        {
            return _Client.Get<T>(ID.ToString());
        }

        public IList<T> FindBy(Query query)
        {
            var keys = QueryTranslator.BuildGetByQueryFrom(query);

            return _Client.GetView<T>("litstar", "user_accounts_by_email", true).Stale(StaleMode.False).Key(keys).ToList<T>();
        }

        public IList<T> FindBy(Query query, int index, int count)
        {
            return _Client.GetView<T>(_designDoc, "user_accounts_by_email", true).ToList<T>();
        }

        protected virtual string BuildKey(T model)
        {
            if (string.IsNullOrEmpty(model.ID.ToString()))
            {
                return Guid.NewGuid().ToString();
            }
            string retval = model.Type + "_" + model.ID.ToString();
            return retval.InflectTo().Underscored;
        }

        private string serializeAndIgnoreId(T obj)
        {
            var json = JsonConvert.SerializeObject(obj,
                new JsonSerializerSettings()
                {
                    ContractResolver = new DocumentIdContractResolver(),
                });
            return json;
        }

        private class DocumentIdContractResolver : CamelCasePropertyNamesContractResolver
        {
            protected override List<MemberInfo> GetSerializableMembers(Type objectType)
            {
                return base.GetSerializableMembers(objectType).Where(o => o.Name != "ID").ToList();
            }
        }
    }
}
