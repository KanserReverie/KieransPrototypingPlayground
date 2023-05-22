using PrototypingPlayground._001GameDevelopmentPatterns._013ServiceLocatorPattern.GenericServiceLocatorPattern.Attributes;
using PrototypingPlayground._001GameDevelopmentPatterns._013ServiceLocatorPattern.GenericServiceLocatorPattern.Services;
using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._013ServiceLocatorPattern.GenericServiceLocatorPattern.Examples.ExampleServices
{
    /*
     * Marking a class with AutoRegisteredService attributes results in it
     * being automatically registered as a part of ServiceLocator's
     * [RuntimeInitializeOnLoadMethod] Initialize method.
     */
    [AutoRegisteredService]
    public class AutoRegisterService : IRegistrable
    {
        public void Work()
        {
            Debug.Log($"{GetType().Name} is performing action.");
        }
    }
}
