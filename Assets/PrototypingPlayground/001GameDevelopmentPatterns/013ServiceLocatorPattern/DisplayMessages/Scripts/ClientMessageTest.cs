using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._013ServiceLocatorPattern.DisplayMessages
{
    public class ClientMessageTest : MonoBehaviour
    {
        private void OnGUI()
        {
            if (GUI.Button(new Rect(Screen.width - 300, 10, 280, 30), "Display 'Hi' In GUI for 2 Seconds"))
            {
                DisplayHiOnGUIForTwoSeconds();
            }
            if (GUI.Button(new Rect(Screen.width - 300, 50, 280, 30), "Log Basic Message"))
            {
                LogBasicMessage();
            }
            if (GUI.Button(new Rect(Screen.width - 300, 90, 280, 30), "<Log Warning>"))
            {
                LogWarning();
            }
            if (GUI.Button(new Rect(Screen.width - 300, 130, 280, 30), "!! Log Error !!"))
            {
                LogError();
            }
        }

        private static void DisplayHiOnGUIForTwoSeconds()
        {
            ServiceLocator.GetService<IGUIDisplayMessage>().DisplayMessageOnGUI("Hi", 2.0f);
        }
        
        private static void LogBasicMessage()
        {
            ServiceLocator.GetService<IMessageLogger>().Log($" Basic Log @ {Time.time}", MessageSeverity.Normal);
        }

        private static void LogWarning()
        {
            ServiceLocator.GetService<IMessageLogger>().Log($" <Warning> Logged @ {Time.time}", MessageSeverity.Warning);
        }

        private static void LogError()
        {
            ServiceLocator.GetService<IMessageLogger>().Log($"  |!|Error|!| @{Time.time}", MessageSeverity.Error);
        }
    }
}