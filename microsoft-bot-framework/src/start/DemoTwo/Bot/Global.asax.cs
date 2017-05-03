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
using WeatherService;

namespace DemoTwo
{
	public class WebApiApplication : System.Web.HttpApplication
	{
        public static IContainer Container { get; set; }

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

            Container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(Container);

        }
	}
}
