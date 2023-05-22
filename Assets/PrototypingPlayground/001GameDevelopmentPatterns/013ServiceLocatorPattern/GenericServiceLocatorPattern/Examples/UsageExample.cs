using PrototypingPlayground._001GameDevelopmentPatterns._013ServiceLocatorPattern.GenericServiceLocatorPattern.Examples.ExampleServices;
using PrototypingPlayground._001GameDevelopmentPatterns._013ServiceLocatorPattern.GenericServiceLocatorPattern.Services;
using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._013ServiceLocatorPattern.GenericServiceLocatorPattern.Examples
{
    public class UsageExample : MonoBehaviour
    {
        private MonoBehaviourBasedService monoBehaviourBasedService;
        private ManuallyRegisteredMonoService manuallyRegisteredMonoService;
        private void Start()
        {
            //Get registered service
            if (ServiceLocator.IsRegistered<MonoBehaviourBasedService>())
            {
                monoBehaviourBasedService = ServiceLocator.Get<MonoBehaviourBasedService>();
                Debug.Log($"{nameof(MonoBehaviourBasedService)} has been registered and received!");
            }
            
            //Get service which you are not sure was registered and handle failure yourself
            try
            {
                manuallyRegisteredMonoService = ServiceLocator.Get<ManuallyRegisteredMonoService>();
            }
            catch (ServiceLocatorException)
            {
                Debug.Log($"Oh no, {nameof(ManuallyRegisteredMonoService)} wasn't registered :(!");
                //Do some action
            }
            
            //Get service and if it doesn't exist create one. Use it carefully as some services may
            //require some configuration. Especially true for MonoBehaviour based services. 
            
            manuallyRegisteredMonoService = ServiceLocator.Get<ManuallyRegisteredMonoService>(true);
            Debug.Log($"I don't care give me {nameof(ManuallyRegisteredMonoService)}!");
            
            //Then use your services
            monoBehaviourBasedService.Work();
            manuallyRegisteredMonoService.Work();
        }
    }
}
