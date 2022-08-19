using System;
using UnityEngine;
namespace PrototypingPlayground._1.GameDevelopmentPatterns.ObserverPattern.MotorBikeSubject.Scripts
{
    public class BikeController : AbstractSubjectBehaviour
    {
        public bool IsTurboOn { get; private set; }

        [SerializeField] private float health = 100.0f;
        public float Health { get; private set; }
        private bool isEngineOn;
        private BikeHUDController bikeHUDController;
        private BikeCameraController bikeCameraController;

        private void Awake()
        {
            bikeHUDController = gameObject.AddComponent<BikeHUDController>();

            bikeCameraController = FindObjectOfType<BikeCameraController>();
        }

        private void Start()
        {
            StartEngine();
        }

        private void OnEnable()
        {
            if (bikeHUDController) 
                AttachObserver(bikeHUDController);
            if (bikeCameraController) 
                AttachObserver(bikeCameraController);
        }

        private void OnDisable()
        {
            if (bikeHUDController) 
                DetachObserver(bikeHUDController);
            if (bikeCameraController) 
                DetachObserver(bikeCameraController);
        }

        public void StartEngine()
        {
            if (!isEngineOn)
            {
                isEngineOn = true;
                NotifyObservers();
            }
        }

        public void ToggleTurbo()
        {
            if (isEngineOn && !IsTurboOn)
            {
                IsTurboOn = true;
                NotifyObservers();
            }
        }

        public void TakeDamage(float _ammount)
        {
            Health -= _ammount;
            if (IsTurboOn)
                IsTurboOn = false;
            NotifyObservers();
            if (Health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
