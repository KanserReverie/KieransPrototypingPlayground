using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._003EventBus.GenericEventBus
{
    /// <summary>
    /// 
    /// A simple 3 second CountDown:
    /// 1) Starts a CountDown once EventBusEvent.Event1 is Published.
    /// 2) Calls EventBusEvent.Event2 at the end of Timer.
    /// 
    /// </summary>
    public class SimpleExample1CountDown : MonoBehaviour
    {
        private float currentCountDownTime;

        private void OnEnable()
        {
            StaticEventBusManager.Subscribe(EventBusEvent.Event1,StartCountDown);
        }
        private void OnDisable()
        {
            StaticEventBusManager.Unsubscribe(EventBusEvent.Event1,StartCountDown);
        }

        private void StartCountDown()
        {
            StartCountDownTimer();
        }
        private void StartCountDownTimer()
        {
            currentCountDownTime = 3;
            
            Invoke(nameof(ReduceTimerBySecond), 1);
            Invoke(nameof(ReduceTimerBySecond), 2);
            Invoke(nameof(ReduceTimerBySecond), 3);
            Invoke(nameof(CallNextEvent), 3);
        }
        
        private void ReduceTimerBySecond()
        {
            currentCountDownTime--;
        }
        
        private void CallNextEvent()
        {
            StaticEventBusManager.Publish(EventBusEvent.Event2);
        }

        private void OnGUI()
        {
            GUI.color = Color.black;
            GUI.Label(new Rect(Screen.width/2-50,5, 100, 30), $"COUNTDOWN: {currentCountDownTime}");
        }
    }
}
