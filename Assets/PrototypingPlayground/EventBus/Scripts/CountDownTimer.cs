using System;
using System.Collections;
using UnityEngine;
namespace PrototypingPlayground.EventBus.Scripts
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
            GUI.color = Color.yellow;
            GUI.Label(new Rect(100,5, 100, 30), $"COUNTDOWN: {_currentCountDownTime}");
        }
    }
}
