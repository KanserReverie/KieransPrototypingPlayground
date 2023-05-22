using System;
using System.Collections.Generic;
using System.Linq;
using PrototypingPlayground._001GameDevelopmentPatterns._013ServiceLocatorPattern.GenericServiceLocatorPattern.Attributes;
using PrototypingPlayground._001GameDevelopmentPatterns._013ServiceLocatorPattern.GenericServiceLocatorPattern.Extensions;

namespace PrototypingPlayground._001GameDevelopmentPatterns._013ServiceLocatorPattern.GenericServiceLocatorPattern.Services
{
    public static class ReflectionService
    {
        public static IEnumerable<Type> GetAllAutoRegisteredServices()
        {
            return AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(assembly => assembly.GetTypesWithCustomAttribute<AutoRegisteredService>())
                .Where(service => typeof(IRegistrable).IsAssignableFrom(service));
        }
    }
}
