using UnityEngine;
namespace PrototypingPlayground._1.GameDevelopmentPatterns.ObserverPattern.MotorBikeSubject.Scripts
{
    public class ClientObserver : MonoBehaviour
    {
        private BikeController bikeController;

        private void Start()
        {
            bikeController = FindObjectOfType<BikeController>();
        }

        private void OnGUI()
        {
            if (bikeController)
            {
                if (GUILayout.Button("Damage Bike"))
                {
                    bikeController.TakeDamage(15f);
                }
                if (GUILayout.Button("Toggle Turbo"))
                {
                    bikeController.ToggleTurbo();
                }
            }
        }
    }
}
