using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructur
{
    public static class IOCExtension
    {
        public static IServiceCollection AddSingleton(this IServiceCollection services, Assembly serviceAssembly, Assembly implementationAssembly, Func<Type, bool> serviceWhere = null, Func<Type, bool> implementationWhere = null)
        {
            if (serviceWhere == null) serviceWhere = u => true;
            if (implementationWhere == null) implementationWhere = u => true;
            var serviceTypes = serviceAssembly.GetExportedTypes().Where(serviceWhere).ToList();
            var implementationTypes = implementationAssembly.GetExportedTypes().Where(implementationWhere).ToList();
            foreach (var implementationType in implementationTypes)
            {
                var interfacesTypes = implementationType.GetInterfaces();
                foreach (var interfacesType in interfacesTypes)
                {
                    var interfaces = serviceTypes.FirstOrDefault(u => u.Name == interfacesType.Name);
                    if (interfaces == null) continue;
                    services.AddSingleton(interfaces, implementationType);
                }
            }
            return services;
        }
    }
}
