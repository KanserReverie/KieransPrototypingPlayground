using UnityEngine;
namespace PrototypingPlayground.GameDevelopmentPatterns.EventBus.BikeEventBus
{
    public class BikeEventBusController : MonoBehaviour
    {
        private bool _isStartCountdownButtonOn;

        private void Start()
        {
            gameObject.AddComponent<BikeStatusController>();
            gameObject.AddComponent<CountDownTimer>();
            gameObject.AddComponent<HUDController>();
            
            Restart();
        }
        private void OnEnable()
        {
            RaceEventBus.Subscribe(RaceEventType.STOP, Restart);
        }
        private void OnDisable()
        {
            RaceEventBus.Unsubscribe(RaceEventType.STOP, Restart);
        }

        private void Restart()
        {
            _isStartCountdownButtonOn = true;
        }

        private void OnGUI()
        {
            if (!_isStartCountdownButtonOn)
                return;
            if (GUILayout.Button("Start Countdown"))
            {
                RaceEventBus.Publish(RaceEventType.COUNTDOWN);
                _isStartCountdownButtonOn = false;
            }
        }
    }
}
