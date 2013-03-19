using System.Configuration;
using System.Web.Http.Dependencies;
using Autofac;
using Autofac.Integration.WebApi;
using Treefort.WebApi.Security;
using VinylShopper.Services.Contracts;
using VinylShopper.Services.Providers;

namespace VinylShopper.Api.Infrastructure
{
    public static class Bootstrapper
    {
         public static IDependencyResolver Start()
         {
             var cb = new ContainerBuilder();
             cb.RegisterApiControllers(System.Reflection.Assembly.GetExecutingAssembly());
             cb.RegisterAssemblyTypes(System.Reflection.Assembly.GetAssembly(typeof (ISearchResult)))
                 .Except<RecordManiaProvider>()
                 .AsImplementedInterfaces();

             RegisterSecurity(cb);

             return new AutofacWebApiDependencyResolver(cb.Build());
         }

         private static void RegisterSecurity(ContainerBuilder cb)
         {
             cb
                .RegisterAssemblyTypes(System.Reflection.Assembly.GetAssembly(typeof(BasicAuthenticationMessageHandler)))
                .Except<GenericRoleProvider>()
                .Except<GenericAuthenticationService>()
                .AsImplementedInterfaces();
             
             cb.RegisterType<BasicAuthenticationMessageHandler>()
                 .AsSelf();

             var user = ConfigurationManager.AppSettings["apiuser"] ?? "apitest";
             var password = ConfigurationManager.AppSettings["apipassword"] ?? "apitest";

             cb.Register(c => new GenericAuthenticationService((u, p) => u == user && p == password))
                 .AsImplementedInterfaces();

             cb.Register(c => new GenericRoleProvider(x => new[] { "Shopper" }))
                 .AsImplementedInterfaces();
         }
    }
}