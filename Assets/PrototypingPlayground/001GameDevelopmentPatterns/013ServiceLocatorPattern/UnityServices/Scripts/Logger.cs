using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._013ServiceLocatorPattern.UnityServices
{
    public class Logger: ILoggerService
    {
        public void Log(string message)
        {
            Debug.Log($"Logged Message: {message}");
        }
    }
}