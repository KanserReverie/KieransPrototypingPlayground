using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._013ServiceLocatorPattern.DisplayMessages
{
    public class GUIDisplayMessage : MonoBehaviour, IGUIDisplayMessage
    {
        private bool areWeDisplayingMessage;
        private string currentMessageToDisplay;
        private float currentMessageDisplayDuration;
        
        public void DisplayMessageOnGUI(string message, float duration)
        {
            if (message == null || duration <= 0)
            {
                ClearMessage();
                return;
            }
            currentMessageToDisplay = message;
            currentMessageDisplayDuration = duration;
            areWeDisplayingMessage = true;
        }

        private void Update()
        {
            if (!areWeDisplayingMessage) return;
            
            currentMessageDisplayDuration -= Time.deltaTime;
            
            if (currentMessageDisplayDuration <= 0)
            {
                ClearMessage();
            }
        }

        private void OnGUI()
        {
            if (!areWeDisplayingMessage) return;
        
            GUILayout.Label($"{currentMessageToDisplay}");
        }

        private void OnEnable()
        {
            ClearMessage();
        }

        private void OnDisable()
        {
            ClearMessage();
        }

        private void ClearMessage()
        {
            currentMessageToDisplay = "";
            currentMessageDisplayDuration = 0;
            areWeDisplayingMessage = false;
        }
    }
}
