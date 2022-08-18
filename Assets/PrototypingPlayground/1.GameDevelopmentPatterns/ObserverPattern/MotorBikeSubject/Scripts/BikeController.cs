using System;
using UnityEngine;
namespace PrototypingPlayground._1.GameDevelopmentPatterns.ObserverPattern.MotorBikeSubject.Scripts
{
    public class BikeController : AbstractSubjectBehaviour
    {
        public bool IsTurboOn { get; private set; }

        [SerializeField] private float health = 100.0f;
        public float Health => health;
        private bool IsEngineOn;
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
        private void StartEngine()
        {
            throw new NotImplementedException();
        }
    }
}
