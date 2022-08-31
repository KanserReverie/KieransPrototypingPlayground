using UnityEngine;
namespace PrototypingPlayground._1.GameDevelopmentPatterns._6.ObserverPattern.MotorBikeSubject
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
