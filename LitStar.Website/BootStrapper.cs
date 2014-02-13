using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LitStar.Controllers.ActionArguments;
using LitStar.Infrastructure.Authentication;
using LitStar.Services.Implementations;
using LitStar.Services.Interfaces;
using LitStar.Core.Domain.Account;
using LitStar.Core.Domain.User;
using StructureMap;
using StructureMap.Configuration.DSL;
using LitStar.Infrastructure.Configuration;
using LitStar.Infrastructure.Logging;
using LitStar.Infrastructure.Email;
using LitStar.Infrastructure.UnitOfWork;
using LitStar.Services.Cache.CacheStorage;

namespace LitStar.Website
{
    public class BootStrapper
    {
        public static void ConfigureStructureMap()
        {
            ObjectFactory.Initialize(x => { x.AddRegistry<ApplicationSettingsRegistry>(); });
            ApplicationSettingsFactory.
                InitializeApplicationSettingsFactory
                                  (ObjectFactory.GetInstance<IApplicationSettings>());
            
            ObjectFactory.Initialize(x => { x.AddRegistry<ModelRegistry>(); });
        }

        public class ModelRegistry : Registry
        {
            public ModelRegistry()
            {
                //if (ApplicationSettingsFactory.
                //    GetApplicationSettings().
                //    PersistenceStrategy.Equals(LitStar.Infrastructure.Domain.PersistenceStrategy.Couchbase.ToString()))
                //{
                //    For<IUnitOfWork>().Use<LitStar.Couchbase.CouchbaseUnitOfWork>();
                //    For<IUserRepository>().Use<LitStar.Couchbase.Repositories.UserRepository>();
                //    For<IStaffRepository>().Use<LitStar.Couchbase.Repositories.StaffRepository>();
                //}
                //else
                //{
                For<IUnitOfWork>().Use<LitStar.Repository.NHibernate.NHUnitOfWork>();
                For<IUserRepository>().Use<LitStar.Repository.NHibernate.Repositories.UserRepository>();
                For<IStaffRepository>().Use<LitStar.Repository.NHibernate.Repositories.StaffRepository>();
                For<ILearnerRepository>().Use<LitStar.Repository.NHibernate.Repositories.LearnerRepository>();
                For<ITutorRepository>().Use<LitStar.Repository.NHibernate.Repositories.TutorRepository>();
                //}


                For<ICacheStorage>().Use<CouchbaseCacheAdapter>();

                
                //Models
                For<IUser>().Use<User>();
                For<IStaff>().Use<Staff>();
                For<ILearner>().Use<Learner>();
                For<IAccount>().Use<Account>();
                For<ITutor>().Use<Tutor>();

                //Services
                For<IUserService>().Use<UserService>();
                For<ILearnerService>().Use<LearnerService>();
                For<ITutorService>().Use<TutorService>();
                For<IStaffService>().Use<StaffService>();

                // Logger
                For<ILogger>().Use
                          <Log4NetAdapter>();
                // Email Service                 
                For<IEmailService>().Use
                        <SMTPService>();
                //Authentication
                For<IExternalAuthenticationService>().Use<JanrainAuthenticationService>();
                For<IFormsAuthentication>().Use<AspFormsAuthentication>();
                For<ILocalAuthenticationService>().Use<CustomAuthenticationService>();
                //Controller Helpers
                For<IActionArguments>().Use<HttpRequestActionArguments>();
            }
        }

        public class ApplicationSettingsRegistry : Registry
        {
            public ApplicationSettingsRegistry()
            {
                // Application Settings                 
                For<IApplicationSettings>().Use
                         <WebConfigApplicationSettings>();
            }
        }

        public static IContainer ConfigureStructureMapWebAPI()
        {
            ObjectFactory.Initialize(x => { x.AddRegistry<ApplicationSettingsRegistry>(); });
            ApplicationSettingsFactory.
                InitializeApplicationSettingsFactory
                                  (ObjectFactory.GetInstance<IApplicationSettings>());
            if (ApplicationSettingsFactory.
                    GetApplicationSettings().
                    PersistenceStrategy.Equals(LitStar.Infrastructure.Domain.PersistenceStrategy.NHibernate.ToString()))
            {
                var container = new Container(x =>
                {

                    x.For<IUnitOfWork>().Use<LitStar.Repository.NHibernate.NHUnitOfWork>();
                    x.For<IUserRepository>().Use<LitStar.Repository.NHibernate.Repositories.UserRepository>();
                    x.For<IStaffRepository>().Use<LitStar.Repository.NHibernate.Repositories.StaffRepository>();
                    x.For<ILearnerRepository>().Use<LitStar.Repository.NHibernate.Repositories.LearnerRepository>();
                    x.For<ITutorRepository>().Use<LitStar.Repository.NHibernate.Repositories.TutorRepository>();
                    //}


                    x.For<ICacheStorage>().Use<CouchbaseCacheAdapter>();


                    //Models
                    x.For<IUser>().Use<User>();
                    x.For<ILearner>().Use<Learner>();
                    x.For<ITutor>().Use<Tutor>();
                    x.For<IStaff>().Use<Staff>();
                    x.For<IAccount>().Use<Account>();

                    //Services
                    x.For<IUserService>().Use<UserService>();
                    x.For<ILearnerService>().Use<LearnerService>();
                    x.For<ITutorService>().Use<TutorService>();
                    x.For<IStaffService>().Use<StaffService>();

                    // Logger
                    x.For<ILogger>().Use
                              <Log4NetAdapter>();
                    // Email Service                 
                    x.For<IEmailService>().Use
                            <SMTPService>();
                    //Authentication
                    x.For<IExternalAuthenticationService>().Use<JanrainAuthenticationService>();
                    x.For<IFormsAuthentication>().Use<AspFormsAuthentication>();
                    x.For<ILocalAuthenticationService>().Use<CustomAuthenticationService>();
                    //Controller Helpers
                    x.For<IActionArguments>().Use<HttpRequestActionArguments>();
                });
                return container;
            }
            return null;
        }
    }
}