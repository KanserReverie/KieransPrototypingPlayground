using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._003EventBus.BikeEventBus
{
    public class HUDController : MonoBehaviour
    {
        private bool isHUDDisplayOn;

        private void OnEnable()
        {
            RaceEventBus.Subscribe(RaceEventType.Start,DisplayHUD);
        }
        private void OnDisable()
        {
            RaceEventBus.Unsubscribe(RaceEventType.Stop,DisplayHUD);
        }

        private void DisplayHUD()
        {
            isHUDDisplayOn = true;
        }

        private void OnGUI()
        {
            if (!isHUDDisplayOn)
                return;
            if(GUILayout.Button("Stop Race"))
            {
                RaceEventBus.Publish(RaceEventType.Stop);
                isHUDDisplayOn = false;
            }
        }
    }
}
