using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._013ServiceLocatorPattern.UnityServices
{
    public class Logger: ILoggerService
    {
        public void Log(string _message)
        {
            Debug.Log($"Logged Message: {_message}");
        }
    }
}