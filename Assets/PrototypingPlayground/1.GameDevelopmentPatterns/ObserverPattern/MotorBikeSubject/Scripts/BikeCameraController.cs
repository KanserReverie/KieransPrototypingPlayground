using PrototypingPlayground._1.GameDevelopmentPatterns.ObserverPattern.AbstractClasses;
using UnityEngine;
namespace PrototypingPlayground._1.GameDevelopmentPatterns.ObserverPattern.MotorBikeSubject.Scripts
{
    public class BikeCameraController : AbstractObserverBehaviour
    {
        private bool isTurboOn;
        private Vector3 initialPosition;
        [SerializeField] private float shakeMagnitude = 0.1f;
        private BikeController bikeController;

        private void OnEnable()
        {
            initialPosition = gameObject.transform.localPosition;
        }

        private void Update()
        {
            if (isTurboOn)
            {
                gameObject.transform.localPosition = initialPosition + (Random.insideUnitSphere * shakeMagnitude);
            }
            else
            {
                gameObject.transform.localPosition = initialPosition;
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
            }
        }
    }
}
