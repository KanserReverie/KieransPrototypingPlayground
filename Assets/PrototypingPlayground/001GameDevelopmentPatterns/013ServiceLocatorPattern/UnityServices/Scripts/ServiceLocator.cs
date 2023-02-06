using System;
using System.Collections.Generic;

namespace PrototypingPlayground._001GameDevelopmentPatterns._013ServiceLocatorPattern.UnityServices
{
    /// <summary>
    /// This is going to be our "White Pages" for this project.
    /// </summary>
    public static class ServiceLocator
    {
        /// <summary> All services to be globally accessible </summary>
        private static readonly IDictionary<Type, object> Services = new Dictionary<Type, Object>();

        public static void RegisterService<T>(T service)
        {
            if (!Services.ContainsKey(typeof(T)))
            {
                Services[typeof(T)] = service;
            }
            else
            {
                throw new
                    ApplicationException
                    ("Service already registered");
            }
        }

        public static T GetService<T>()
        {
            try
            {
                return (T) Services[typeof(T)];
            }
            catch
            {
                throw new
                    ApplicationException
                    ("Requested service not found.");
            }
        }
    }
}