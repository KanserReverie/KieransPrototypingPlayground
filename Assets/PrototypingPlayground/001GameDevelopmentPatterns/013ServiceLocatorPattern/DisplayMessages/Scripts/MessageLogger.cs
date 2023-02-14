using System;
using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._013ServiceLocatorPattern.DisplayMessages
{
    public class MessageLogger : MonoBehaviour, IMessageLogger
    {
        public void Log(string _message, MessageSeverity _messageSeverity)
        {
            switch (_messageSeverity)
            {
                case MessageSeverity.Normal:
                    Debug.Log($"Logged Message: {_message}");
                    break;
                case MessageSeverity.Warning:
                    Debug.LogWarning($"Logged Warning: {_message}");
                    break;
                case MessageSeverity.Error:
                    Debug.LogError($"Logged Error: {_message}");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(_messageSeverity), _messageSeverity, null);
            }
        }
    }
}