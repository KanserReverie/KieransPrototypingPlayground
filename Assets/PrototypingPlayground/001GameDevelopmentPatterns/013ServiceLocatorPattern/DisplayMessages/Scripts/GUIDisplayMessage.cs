
using System;
using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._013ServiceLocatorPattern.DisplayMessages
{
    public class GUIDisplayMessage : MonoBehaviour, IGUIDisplayMessage
    {
        private bool _areWeDisplayingMessage;
        private string _currentMessageToDisplay;
        private float _currentMessageDisplayDuration;
        
        public void DisplayMessageOnGUI(string _message, float _duration)
        {
            if (_message == null || _duration <= 0)
            {
                ClearMessage();
                return;
            }
            _currentMessageToDisplay = _message;
            _currentMessageDisplayDuration = _duration;
            _areWeDisplayingMessage = true;
        }

        private void Update()
        {
            if (!_areWeDisplayingMessage) return;
            
            _currentMessageDisplayDuration -= Time.deltaTime;
            
            if (_currentMessageDisplayDuration <= 0)
            {
                ClearMessage();
            }
        }

        private void OnGUI()
        {
            if (!_areWeDisplayingMessage) return;
        
            GUILayout.Label($"{_currentMessageToDisplay}");
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
            _currentMessageToDisplay = "";
            _currentMessageDisplayDuration = 0;
            _areWeDisplayingMessage = false;
        }
    }
}
