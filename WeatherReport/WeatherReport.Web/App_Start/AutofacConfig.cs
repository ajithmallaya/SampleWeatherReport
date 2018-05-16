using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using WeatherReport.Web.Helper;
using WeatherReport.Web.Services;

namespace WeatherReport.Web
{
    public class AutofacConfig
    {
        public static IContainer Configure()
        {
            var executingAssembly = Assembly.GetExecutingAssembly();

            var builder = new ContainerBuilder();

            builder.RegisterControllers(executingAssembly);

            RegisterApplicationServiceTypes(builder);

            var container = builder.Build();

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            return container;
        }

        private static void RegisterApplicationServiceTypes(ContainerBuilder builder)
        {
            builder.RegisterType<WeatherService>().As<IWeatherService>().InstancePerRequest();
            builder.Register(context => new HttpClient()).Named<HttpClient>("WeatherApi").SingleInstance();
            builder.Register(context => new ApiHelper(
                context.ResolveNamed<HttpClient>("WeatherApi"))).As<IApiHelper>().InstancePerRequest();
        }
    }
}