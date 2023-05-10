using System;
using System.Collections.Generic;

namespace PrototypingPlayground._001GameDevelopmentPatterns._013ServiceLocatorPattern.DisplayMessages
{
    /// <summary>
    /// This is our global white pages.
    /// </summary>
    public static class ServiceLocator
    {
        /// <summary>
        /// Our global private dictionary of service we want to reference.
        /// </summary>
        private static readonly IDictionary<Type, object> Services = new Dictionary<Type, object>();
        
        /// <summary>
        /// Register the new service if one isn't already there with the same type.
        /// </summary>
        public static void RegisterService<TTypeOfServiceToAdd>(TTypeOfServiceToAdd service)
        {
            // Does our dictionary NOT contain the Key as a type?
            if (!Services.ContainsKey(typeof(TTypeOfServiceToAdd)))
            {
                // At the Key Type of Service, add the _service.
                Services[typeof(TTypeOfServiceToAdd)] = service;
            }
            // Else (if we already have a key here).
            else
            {
                // Throw an Application Exception telling the user we already have the Service Registered.
                throw new ApplicationException("Service already registered");
            }
        }
        
        /// <summary>
        /// Trys to get a service of the requested type, and if not in our directory throw an exception.
        /// </summary>
        public static TTypeOfServiceToGet GetService<TTypeOfServiceToGet>()
        {
            // Try to get the service if it has been added.
            try
            {
                // Return the requested service that is in our dictionary.
                return (TTypeOfServiceToGet) Services[typeof(TTypeOfServiceToGet)];
            }
            catch
            {
                // Throw an Application Exemption telling them we don't have the service in our directory.
                throw new ApplicationException("Requested service not found.");
            }
        }
    }
}
