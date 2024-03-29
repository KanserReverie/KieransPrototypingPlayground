using PrototypingPlayground._001GameDevelopmentPatterns._006ObserverPattern.GenericObserverPattern;
using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._006ObserverPattern.MotorBikeSubject
{
    [RequireComponent(typeof(ParticleSystem))]
    public class HealthParticleSystem : AbstractObserverBehaviour
    {
        private ParticleSystem healthParticles;
        private bool lowHealth;
        private BikeController bikeController;

        private void OnEnable()
        {
            bikeController = FindObjectOfType<BikeController>();
            healthParticles = GetComponent<ParticleSystem>();
            healthParticles.Stop();
        }
        public override void Notify(AbstractSubjectBehaviour subjectBehaviour)
        {
            if (!bikeController)
            {
                bikeController = FindObjectOfType<BikeController>();
            }

            if (!healthParticles)
            {
                healthParticles = GetComponent<ParticleSystem>();
            }
            
            if (bikeController && healthParticles)
            {
                if (bikeController.CurrentHealth <= 30)
                {
                    healthParticles.Play();
                }
                else
                {
                    healthParticles.Stop();
                }
            }
        }
    }
}
