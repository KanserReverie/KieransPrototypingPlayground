using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._003EventBus.BikeEventBus
{
    public class BikeStatusController : MonoBehaviour
    {
        private string bikeStatus;

        private void OnEnable()
        {
            RaceEventBus.Subscribe(RaceEventType.Start, StartBike);
            RaceEventBus.Subscribe(RaceEventType.Stop, StopBike);
        }

        private void OnDisable()
        {
            RaceEventBus.Unsubscribe(RaceEventType.Start, StartBike);
            RaceEventBus.Unsubscribe(RaceEventType.Stop, StopBike);
        }
        private void StartBike()
        {
            bikeStatus = "Started";
        }
        private void StopBike()
        {
            bikeStatus = "Stopped";
        }
        
        private void OnGUI()
        {
            GUI.color = Color.yellow;
            GUI.Label(new Rect(15,50,200,20), $"BIKE STATUS: {bikeStatus}");
        }
    }
}
