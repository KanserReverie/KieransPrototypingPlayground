using System;
using System.Collections.Generic;

namespace PrototypingPlayground._001GameDevelopmentPatterns._013ServiceLocatorPattern.GenericServiceLocatorPattern
{
    /// <summary>
    /// This is our global "White pages" to access different classes
    /// </summary>
    public static class ServiceLocator
    {
        /// <summary>
        /// Our global private dictionary of services we want to reference
        /// </summary>
        private static readonly IDictionary<Type, object> ServicesDictionary = new Dictionary<Type, object>();
        
        /// <summary>
        /// Register or change a new service to be globally referenced
        /// </summary>
        /// <param name="service"> Service to register</param>
        public static void RegisterService<TTypeOfServiceToRegister>(TTypeOfServiceToRegister service)
        {
            if (ServicesDictionary.ContainsKey(typeof(TTypeOfServiceToRegister)))
            {
                ServicesDictionary.Remove(typeof(TTypeOfServiceToRegister));
            }
            ServicesDictionary[typeof(TTypeOfServiceToRegister)] = service;
        }
        
        /// <summary>
        /// Trys to get a service of the requested type
        /// </summary>
        /// <returns> The service instance</returns>
        /// <exception cref="ApplicationException"> If the service is not registered</exception>
        public static TTypeOfServiceToGet GetService<TTypeOfServiceToGet>()
        {
            try
            {
                return (TTypeOfServiceToGet) ServicesDictionary[typeof(TTypeOfServiceToGet)];
            }
            catch
            {
                throw new ApplicationException("Requested service not found.");
            }
        }
    }
}
