using PrototypingPlayground._001GameDevelopmentPatterns._006ObserverPattern.AbstractClasses;
using PrototypingPlayground.UsefulScripts;
using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._006ObserverPattern.MotorBikeSubject
{
    public class BikeController : AbstractSubjectBehaviour
    {
        public bool IsTurboOn { get; private set; }

        [SerializeField] private float maxHealth = 100.0f;
        public float CurrentHealth { get; private set; }
        private bool isEngineOn;
        private BikeHUDController bikeHUDController;
        private BikeCameraController bikeCameraController;
        private HealthParticleSystem bikeHealthParticleSystem;

        private void Awake()
        {
            bikeHUDController = FindObjectOfType<BikeHUDController>();
            bikeCameraController = FindObjectOfType<BikeCameraController>();
            bikeHealthParticleSystem = FindObjectOfType<HealthParticleSystem>();
        }

        private void Start()
        {
            StartEngine();
            CurrentHealth = maxHealth;
            NotifyObservers();
        }

        private void OnEnable()
        {
            if (bikeHUDController) 
                AttachObserver(bikeHUDController);
            if (bikeCameraController) 
                AttachObserver(bikeCameraController);
            if (bikeHealthParticleSystem) 
                AttachObserver(bikeHealthParticleSystem);
            NotifyObservers();
        }

        private void OnDisable()
        {
            if (bikeHUDController) 
                DetachObserver(bikeHUDController);
            if (bikeCameraController) 
                DetachObserver(bikeCameraController);
            if (bikeHealthParticleSystem) 
                DetachObserver(bikeHealthParticleSystem);
            CommonlyUsedStaticMethods.QuitGame();
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
            if (isEngineOn)
            {
                IsTurboOn = !IsTurboOn;
                NotifyObservers();
            }
        }

        public void TakeDamage(float _ammount)
        {
            CurrentHealth -= _ammount;
            if (IsTurboOn)
                IsTurboOn = false;
            NotifyObservers();
            if (CurrentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
