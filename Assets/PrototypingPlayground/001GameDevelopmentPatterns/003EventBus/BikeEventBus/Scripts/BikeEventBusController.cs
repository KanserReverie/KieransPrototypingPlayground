using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._003EventBus.BikeEventBus
{
    public class BikeEventBusController : MonoBehaviour
    {
        private bool isStartCountdownButtonOn;

        private void Start()
        {
            gameObject.AddComponent<BikeStatusController>();
            gameObject.AddComponent<CountDownTimer>();
            gameObject.AddComponent<HUDController>();
            
            Restart();
        }
        private void OnEnable()
        {
            RaceEventBus.Subscribe(RaceEventType.Stop, Restart);
        }
        private void OnDisable()
        {
            RaceEventBus.Unsubscribe(RaceEventType.Stop, Restart);
        }

        private void Restart()
        {
            isStartCountdownButtonOn = true;
        }

        private void OnGUI()
        {
            if (!isStartCountdownButtonOn)
                return;
            if (GUILayout.Button("Start Countdown"))
            {
                RaceEventBus.Publish(RaceEventType.Countdown);
                isStartCountdownButtonOn = false;
            }
        }
    }
}
