using System;
using UnityEngine;

namespace PrototypingPlayground._002BasicConcepts.UnityTimer
{
    public class TimerExample : MonoBehaviour
    {
        [SerializeField] private Timer timerReference;
        public GameObject turnOnObject;

        private void OnGUI()
        {
            GUILayout.BeginArea(new Rect(Screen.width -240, 20, 200,120));
            if (GUILayout.Button("Start Timer"))
            {
                timerReference.StartTimer();
            }
            GUILayout.EndArea();
        }

        public void Update()
        {
            if (timerReference.isTimerRunning && !turnOnObject.activeSelf)
            {
                turnOnObject.SetActive(true);
            }
            else if (!timerReference.isTimerRunning && turnOnObject.activeSelf)
            {
                turnOnObject.SetActive(false);
            }
        }
    }
}