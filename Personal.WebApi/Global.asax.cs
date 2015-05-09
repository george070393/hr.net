using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using AutoMapper;
using Microsoft.Practices.Unity;
using Personal.Entities;
using Personal.Persistence;

namespace Personal.WebApi
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            var container = new UnityContainer();
            container.RegisterType<IHrContext, InMemoryHrContext>(new ContainerControlledLifetimeManager());
            GlobalConfiguration.Configuration.DependencyResolver = new UnityResolver(container);
            Mapper.CreateMap<Job, Job>();
            Mapper.CreateMap<Department, Department>();
            Mapper.CreateMap<Employee, Employee>();
            Mapper.CreateMap<Location, Location>();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}