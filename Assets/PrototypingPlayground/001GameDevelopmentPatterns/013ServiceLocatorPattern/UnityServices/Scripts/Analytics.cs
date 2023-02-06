using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._013ServiceLocatorPattern.UnityServices
{
    public class Analytics : IAnalyticsService
    {
        public void SendEvent(string _eventName)
        {
            Debug.Log($"Sent: {_eventName}");
        }
    }
}