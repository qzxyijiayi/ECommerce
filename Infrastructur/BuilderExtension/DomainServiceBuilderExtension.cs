using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Infrastructur.BuilderExtension
{
    public static class DomainServiceBuilderExtension
    {
        public static IServiceCollection AddDomainService(this IServiceCollection services)
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var IApplicationServiceAss = Assembly.LoadFrom(basePath + "IDomainService.dll");
            var ApplicationServiceAss = Assembly.LoadFrom(basePath + "DomainService.dll");

            return services.AddSingleton(IApplicationServiceAss, ApplicationServiceAss, u => u.Name.EndsWith("DomainService"), u => u.Name.EndsWith("DomainService"));
        }
    }
}
