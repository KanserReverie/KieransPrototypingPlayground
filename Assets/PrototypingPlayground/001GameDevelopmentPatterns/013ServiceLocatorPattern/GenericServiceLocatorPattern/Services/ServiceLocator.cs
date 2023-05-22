using System;
using System.Collections.Generic;
using PrototypingPlayground._001GameDevelopmentPatterns._013ServiceLocatorPattern.GenericServiceLocatorPattern.Extensions;
using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._013ServiceLocatorPattern.GenericServiceLocatorPattern.Services
{
    public class ServiceLocator : MonoBehaviour
    {
        private static readonly Dictionary<Type, object> Services = new Dictionary<Type, object>();

        [RuntimeInitializeOnLoadMethod]
        public static void Initialize()
        {
            foreach (var serviceType in ReflectionService.GetAllAutoRegisteredServices())
            {
                if (IsRegistered(serviceType)) continue;
                
                if (serviceType.IsMonoBehaviour())
                {
                    FindOrCreateMonoService(serviceType);
                }
                else
                {
                    RegisterNewInstance(serviceType);
                }
            }
        }

        public static void Register<TService>(TService service, bool safe = true) where TService : IRegistrable, new()
        {
            var serviceType = typeof(TService);
            if (IsRegistered<TService>() && safe)
            {
                throw new ServiceLocatorException($"{serviceType.Name} has been already registered.");
            }

            Services[typeof(TService)] = service;
        }

        public static TService Get<TService>(bool forced = false) where TService : IRegistrable, new()
        {
            var serviceType = typeof(TService);
            if (IsRegistered<TService>())
            {
                return (TService) Services[serviceType];
            } 
            if (!forced) 
                throw new ServiceLocatorException($"{serviceType.Name} hasn't been registered.");

            var service = serviceType.IsMonoBehaviour() ? 
                (TService) FindOrCreateMonoService(serviceType) : new TService();
          
            Register(service);
            return service;
        }

        public static bool IsRegistered(Type t)
        {
            return Services.ContainsKey(t);
        }

        public static bool IsRegistered<TService>()
        {
            return IsRegistered(typeof(TService));
        }
        

        private static void RegisterNewInstance(Type serviceType)
        {
            Services[serviceType] = Activator.CreateInstance(serviceType);
        }
        
        private static object FindOrCreateMonoService(Type serviceType)
        {
            var inGameService = FindObjectOfType(serviceType);
            if (inGameService == null)
            {
                var newObject = new GameObject();
                newObject.AddComponent(serviceType);
                newObject.name = serviceType.Name;
                inGameService = newObject.GetComponent(serviceType);
            }
            Services[serviceType] = inGameService;
            return inGameService;
        }
    }
    
    public class ServiceLocatorException : Exception
    {
        public ServiceLocatorException(string message) : base(message) {}
    }

}
