﻿using System.Web.Mvc;
using Cares.WebBase.Mvc;
using Cares.WebBase.UnityConfiguration;
using Microsoft.Practices.Unity;

namespace Cares.WebBase
{
    public static class TypeRegistrations
    {
        public static void RegisterTypes(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType(typeof(IControllerActivator), typeof(UnityControllerActivator));
            unityContainer.RegisterType<IExceptionFilter, LogExceptionFilterAttribute>();
            unityContainer.RegisterType<System.Web.Http.Filters.IExceptionFilter, LogExceptionFilterAttribute>();
        }
    }
}
