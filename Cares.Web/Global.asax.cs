﻿using IdentitySample.Models;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System.Web.Http;

namespace Cares.Web
{
    // Note: For instructions on enabling IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=301868
    public class MvcApplication : System.Web.HttpApplication
    {
        #region Private
        private static IUnityContainer container;
        /// <summary>
        /// Configure Logger
        /// </summary>
        private void ConfigureLogger()
        {
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory());
            IConfigurationSource configurationSource = ConfigurationSourceFactory.Create();
            LogWriterFactory logWriterFactory = new LogWriterFactory(configurationSource);
            Logger.SetLogWriter(logWriterFactory.Create());
        }
        /// <summary>
        /// Create the unity container
        /// </summary>
        private static IUnityContainer CreateUnityContainer()
        {
            container = WebBase.UnityConfiguration.UnityWebActivator.Container;
            RegisterTypes();

            return container;
        }
        /// <summary>
        /// Register types with the IoC
        /// </summary>
        private static void RegisterTypes()
        {
            Cares.WebBase.TypeRegistrations.RegisterTypes(container);
            Implementation.TypeRegistrations.RegisterType(container);

        }
        /// <summary>
        /// Register unity 
        /// </summary>
        private static void RegisterIoC()
        {
            if (container == null)
            {
                container = CreateUnityContainer();
            }
        }
        #endregion
        protected void Application_Start()
        {
            RegisterIoC();
            AreaRegistration.RegisterAllAreas();
            ConfigureLogger();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters, container);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Set MVC resolver
            //DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            DependencyResolver.SetResolver(new WebBase.UnityConfiguration.UnityDependencyResolver(container));
            // Set Web Api resolver
            //GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = new WebBase.UnityConfiguration.UnityDependencyResolver(container);
        }
    }
}