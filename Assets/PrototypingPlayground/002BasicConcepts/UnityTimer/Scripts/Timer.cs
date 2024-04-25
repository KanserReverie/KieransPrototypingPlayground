using System;
using UnityEngine;

namespace PrototypingPlayground._002BasicConcepts.UnityTimer
{
    public class Timer : MonoBehaviour
    {
        // Variables
        // What is the time.
        public float elapsedTime;
        // Timer duration.
        public float timerDuration = 0.6f;
        // Is the timer still running?
        public bool isTimerRunning;
        
        // Start Timer.
        public void StartTimer()
        {
            Debug.Log("Start Timer");
            isTimerRunning = true;
            elapsedTime = 0f;
        }
        
        // Stop Timer.
        public void StopTimer()
        {
            isTimerRunning = false;
            Debug.Log("Stop Timer");
        }

        private void Update()
        {
            if (isTimerRunning)
            {
                elapsedTime += Time.deltaTime;
                if (elapsedTime >= timerDuration)
                {
                    TimerHasEnded();
                }
            }
        }

        private void TimerHasEnded()
        {
            StopTimer();
            Debug.Log("Timer Has Ended");
        }
    }
}
