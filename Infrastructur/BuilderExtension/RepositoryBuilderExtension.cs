using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Infrastructur.BuilderExtension
{
    public static class RepositoryBuilderExtension
    {
        public static IServiceCollection AddRepositoryService(this IServiceCollection services)
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var IApplicationServiceAss = Assembly.LoadFrom(basePath + "IRepository.dll");
            var ApplicationServiceAss = Assembly.LoadFrom(basePath + "Repository.dll");

            return services.AddSingleton(IApplicationServiceAss, ApplicationServiceAss, u => u.Name.EndsWith("Repository"), u => u.Name.EndsWith("Repository"));
        }
    }
}
