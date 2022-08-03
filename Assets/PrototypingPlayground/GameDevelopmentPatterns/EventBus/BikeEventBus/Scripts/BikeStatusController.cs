using UnityEngine;
namespace PrototypingPlayground.EventBus.BikeEventBus
{
    public class BikeStatusController : MonoBehaviour
    {
        private string _bikeStatus;

        private void OnEnable()
        {
            RaceEventBus.Subscribe(RaceEventType.START, StartBike);
            RaceEventBus.Subscribe(RaceEventType.STOP, StopBike);
        }

        private void OnDisable()
        {
            RaceEventBus.Unsubscribe(RaceEventType.START, StartBike);
            RaceEventBus.Unsubscribe(RaceEventType.STOP, StopBike);
        }
        private void StartBike()
        {
            _bikeStatus = "Started";
        }
        private void StopBike()
        {
            _bikeStatus = "Stopped";
        }
        
        private void OnGUI()
        {
            GUI.color = Color.yellow;
            GUI.Label(new Rect(15,50,200,20), $"BIKE STATUS: {_bikeStatus}");
        }
    }
}
