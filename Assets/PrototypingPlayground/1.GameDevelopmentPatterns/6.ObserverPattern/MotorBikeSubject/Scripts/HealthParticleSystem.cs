using PrototypingPlayground._1.GameDevelopmentPatterns._6.ObserverPattern.AbstractClasses;
using UnityEngine;
namespace PrototypingPlayground._1.GameDevelopmentPatterns._6.ObserverPattern.MotorBikeSubject
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
        public override void Notify(AbstractSubjectBehaviour _subjectBehaviour)
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
