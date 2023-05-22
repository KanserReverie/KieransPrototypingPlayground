using PrototypingPlayground._001GameDevelopmentPatterns._013ServiceLocatorPattern.GenericServiceLocatorPattern.Services;
using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._013ServiceLocatorPattern.GenericServiceLocatorPattern.Examples.ExampleServices
{
    /*
     * If for some reason you do not want to automatically register
     * a service at a scene start you can do it manually using
     * ServiceLocator.Register(serviceRef); at any point
     */
    public class ManuallyRegisteredMonoService : MonoRegistrable
    {
        public void Work()
        {
            Debug.Log($"{GetType().Name} is performing action.");
        }

        public void RegisterMe()
        {
            ServiceLocator.Register(this);
        }
    }
}
