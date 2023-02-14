using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._013ServiceLocatorPattern.DisplayMessages
{
    public class GlobalServiceLocator : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            RegisterGlobalServices();
        }

        private void RegisterGlobalServices()
        {
            IGUIDisplayMessage guiDisplayMessage = gameObject.AddComponent<GUIDisplayMessage>();
            ServiceLocator.RegisterService(guiDisplayMessage);

            IMessageLogger messageLogger = gameObject.AddComponent<MessageLogger>();
            ServiceLocator.RegisterService(messageLogger);
        }
    }
}