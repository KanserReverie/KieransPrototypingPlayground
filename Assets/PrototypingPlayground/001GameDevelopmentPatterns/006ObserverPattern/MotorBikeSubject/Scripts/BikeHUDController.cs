using PrototypingPlayground._001GameDevelopmentPatterns._006ObserverPattern.GenericObserverPattern;
using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._006ObserverPattern.MotorBikeSubject
{
    public class BikeHUDController : AbstractObserverBehaviour
    {
        private bool isTurboOn;
        private float currentHealth;
        private BikeController bikeController;

        private void OnGUI()
        {
            if (bikeController)
            {
                GUILayout.BeginArea(new Rect(50, 50, 140, 100));

                GUILayout.BeginHorizontal("box");
                GUILayout.Label($"Health: {currentHealth}");
                GUILayout.EndHorizontal();

                if (isTurboOn)
                {
                    GUILayout.BeginHorizontal("box");
                    GUILayout.Label("TURBO ACTIVATED!");
                    GUILayout.EndHorizontal();
                }

                if (currentHealth <= 50)
                {
                    GUILayout.BeginHorizontal("box");
                    GUILayout.Label("WARNING: low health");
                    GUILayout.EndHorizontal();
                }
                GUILayout.EndArea();
            }
        }
        public override void Notify(AbstractSubjectBehaviour _subjectBehaviour)
        {
            if (!bikeController)
            {
                bikeController = FindObjectOfType<BikeController>();
            }
            if (bikeController)
            {
                isTurboOn = bikeController.IsTurboOn;
                currentHealth = bikeController.CurrentHealth;
            }
        }
    }
}
