using Autofac;
using Autofac.Integration.WebApi;
using GeoLocatorService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Autofac.Builder;
using WeatherService;

namespace DemoOne
{
	public class WebApiApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			GlobalConfiguration.Configure(WebApiConfig.Register);
            

            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<GeoService>().As<IGeoService>();
            builder.RegisterType<WeatherService.WeatherService>().As<IWeatherService>();

            //builder.RegisterType<OfflineGeoService>().As<IGeoService>();
            //builder.RegisterType<OfflineWeatherService>().As<IWeatherService>();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
	}
}
