using PrototypingPlayground._001GameDevelopmentPatterns._013ServiceLocatorPattern.GenericServiceLocatorPattern.Attributes;
using PrototypingPlayground._001GameDevelopmentPatterns._013ServiceLocatorPattern.GenericServiceLocatorPattern.Services;
using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._013ServiceLocatorPattern.GenericServiceLocatorPattern.Examples.ExampleServices
{
    /*
     * Instead of implementing IRegistrable interface the class the Service can
     * extend the MonoRegistrable class. The MonoRegistrable extends MonoBehaviour
     * and implements IRegistrable interface. If a script marked as MonoRegistrable
     * is dropped onto GameObject, the GameObject's name is automatically changed
     * to the service name.
     *
     * MonoRegistrable can also be marked with [AutoRegisteredService] attribute.
     * In this case the ServiceLocator will first try to locate existing service
     * in the active scene. If it not found, new GameObject with this script added
     * to it will be instantiated. 
     */
    [AutoRegisteredService]
    public class MonoBehaviourBasedService : MonoRegistrable
    {
        public void Work()
        {
            Debug.Log($"{GetType().Name} is performing action.");
        }
    }
}
