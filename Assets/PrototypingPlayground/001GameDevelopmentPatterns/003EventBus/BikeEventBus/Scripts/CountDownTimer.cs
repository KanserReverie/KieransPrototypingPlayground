using System.Collections;
using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._003EventBus.BikeEventBus
{
    public class CountDownTimer : MonoBehaviour
    {
        [SerializeField] private float countDownDuration = 3f;
        private float currentCountDownTime;

        private void OnEnable()
        {
            RaceEventBus.Subscribe(RaceEventType.Countdown,StartCountDown);
        }
        private void OnDisable()
        {
            RaceEventBus.Unsubscribe(RaceEventType.Countdown,StartCountDown);
        }

        private void StartCountDown()
        {
            StartCoroutine(StartCountDownTimer());
        }
        private IEnumerator StartCountDownTimer()
        {
            currentCountDownTime = countDownDuration;

            while (currentCountDownTime > 0)
            {
                yield return new WaitForSeconds(1f);
                currentCountDownTime--;
            }
            RaceEventBus.Publish(RaceEventType.Start);
        }

        private void OnGUI()
        {
            GUI.color = Color.black;
            GUI.Label(new Rect(Screen.width/2-50,5, 100, 30), $"COUNTDOWN: {currentCountDownTime}");
        }
    }
}
