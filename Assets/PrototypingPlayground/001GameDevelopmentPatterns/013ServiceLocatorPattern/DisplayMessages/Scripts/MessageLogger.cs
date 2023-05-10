using System;
using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._013ServiceLocatorPattern.DisplayMessages
{
    public class MessageLogger : MonoBehaviour, IMessageLogger
    {
        public void Log(string message, MessageSeverity messageSeverity)
        {
            switch (messageSeverity)
            {
                case MessageSeverity.Normal:
                    Debug.Log($"Logged Message: {message}");
                    break;
                case MessageSeverity.Warning:
                    Debug.LogWarning($"Logged Warning: {message}");
                    break;
                case MessageSeverity.Error:
                    Debug.LogError($"Logged Error: {message}");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(messageSeverity), messageSeverity, null);
            }
        }
    }
}