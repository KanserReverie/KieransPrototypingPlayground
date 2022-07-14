using Unity.VisualScripting;
using UnityEngine;
namespace PrototypingPlayground.CommandPattern.OverwriteLastPlay
{
    public class MarbleCommandInvoker : MonoBehaviour
    {
        private bool areWeRecording;
        private bool hasGameStarted;

        private void Start()
        {
            PauseGameBeforeRecording();
        }
        private void PauseGameBeforeRecording()
        {
            Time.timeScale = 0;
            areWeRecording = false;
            hasGameStarted = false;
        }

        private void Update()
        {
            if (HasTheGameStarted()) return;
        }
        
        private bool HasTheGameStarted()
        {
            if (hasGameStarted) return true;
            
            if (Input.anyKey)
            {
                Time.timeScale = 1;
                areWeRecording = true;
                hasGameStarted = true;
                return true;
            }
            return false;
        }
    }
}
