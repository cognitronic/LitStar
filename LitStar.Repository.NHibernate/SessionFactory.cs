using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Repository.NHibernate.SessionStorage;
using NHibernate;
using NHibernate.Cfg;
using System.Web;
using log4net;
using LitStar.Infrastructure.Configuration;
using FluentNHibernate.Cfg;
using LitStar.Repository.NHibernate.Mappings;

namespace LitStar.Repository.NHibernate
{
    public class SessionFactory
    {
        private static ISessionFactory _sessionFactory;
        
        private static void Init()
        {
            _sessionFactory = Fluently.Configure()
                .Database(FluentNHibernate.Cfg.Db
                .MsSqlConfiguration.MsSql2008
                .ConnectionString(c =>
                    c.FromConnectionStringWithKey("NHibernate")).ShowSql())
                    .Mappings(m =>
                    m.FluentMappings.AddFromAssemblyOf<UserMap>())
                    .BuildSessionFactory();
        }

        private static ISessionFactory GetSessionFactory()
        {
            if (_sessionFactory == null)
                Init();
            return _sessionFactory;
        }

        private static ISession GetNewSession()
        {
            return GetSessionFactory().OpenSession();
        }

        public static ISession GetCurrentSession()
        {
            ISessionStorageContainer sessionStorageContainer = SessionStorageFactory.GetStorageContainer();

            ISession currentSession = sessionStorageContainer.GetCurrentSession();
            if (currentSession == null)
            {
                currentSession = GetNewSession();
                sessionStorageContainer.Store(currentSession);
            }
            return currentSession;
        }
    }
}
