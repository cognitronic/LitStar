using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CouchbaseModelViews.Framework;
using System.Reflection;
using LitStar.Infrastructure.Configuration;
using LitStar.Infrastructure.Logging;
using LitStar.Infrastructure.Email;
using LitStar.Controllers;
using StructureMap;

namespace LitStar.Website
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ModelMetadataProviders.Current = new MyMetadataProvider(); 
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;


            GlobalConfiguration.Configuration.DependencyResolver = new WebApiContrib.IoC.StructureMap.StructureMapResolver(BootStrapper.ConfigureStructureMapWebAPI());

            AreaRegistration.RegisterAllAreas();

            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            

            BootStrapper.ConfigureStructureMap();

            
            Services.AutoMapperBootStrapper.ConfigureAutoMapper();
            LitStar.Controllers.AutoMapperBootStrapper.ConfigureAutoMapper();

            LoggingFactory.InitializeLogFactory(ObjectFactory.GetInstance<ILogger>());

            EmailServiceFactory.InitializeEmailServiceFactory
                                  (ObjectFactory.GetInstance<IEmailService>());
            
            ControllerBuilder.Current.SetControllerFactory(new IoCControllerFactory());

            LoggingFactory.GetLogger().Log("Application Started");

            ModelBinders.Binders.DefaultBinder = new App_Start.GenericModelBinder();
        }
    }
}