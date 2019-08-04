using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Infrastructur.BuilderExtension
{
    public static class ApplicationBuilderExtension
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var IApplicationServiceAss = Assembly.LoadFrom(basePath + "IApplicationService.dll");
            var ApplicationServiceAss = Assembly.LoadFrom(basePath + "ApplicationService.dll");

            return services.AddSingleton(IApplicationServiceAss, ApplicationServiceAss, u => u.Name.EndsWith("Application"), u => u.Name.EndsWith("Application"));
        }
    }
}
