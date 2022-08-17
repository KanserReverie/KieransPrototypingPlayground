using System.Collections;
using UnityEngine;
namespace PrototypingPlayground._1.GameDevelopmentPatterns.EventBus.BikeEventBus.Scripts
{
    public class CountDownTimer : MonoBehaviour
    {
        [SerializeField] private float countDownDuration = 3f;
        private float _currentCountDownTime;

        private void OnEnable()
        {
            RaceEventBus.Subscribe(RaceEventType.COUNTDOWN,StartCountDown);
        }
        private void OnDisable()
        {
            RaceEventBus.Unsubscribe(RaceEventType.COUNTDOWN,StartCountDown);
        }

        private void StartCountDown()
        {
            StartCoroutine(StartCountDownTimer());
        }
        private IEnumerator StartCountDownTimer()
        {
            _currentCountDownTime = countDownDuration;

            while (_currentCountDownTime > 0)
            {
                yield return new WaitForSeconds(1f);
                _currentCountDownTime--;
            }
            RaceEventBus.Publish(RaceEventType.START);
        }

        private void OnGUI()
        {
            GUI.color = Color.black;
            GUI.Label(new Rect(Screen.width/2-50,5, 100, 30), $"COUNTDOWN: {_currentCountDownTime}");
        }
    }
}
