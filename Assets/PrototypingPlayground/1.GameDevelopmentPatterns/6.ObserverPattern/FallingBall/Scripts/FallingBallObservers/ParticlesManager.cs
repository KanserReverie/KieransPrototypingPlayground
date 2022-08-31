using PrototypingPlayground._1.GameDevelopmentPatterns._6.ObserverPattern.AbstractClasses;
using PrototypingPlayground._1.GameDevelopmentPatterns._6.ObserverPattern.FallingBall.AbstractClasses;
using UnityEngine;
namespace PrototypingPlayground._1.GameDevelopmentPatterns._6.ObserverPattern.FallingBall.FallingBallObservers
{
    public class ParticlesManager : AbstractFallingBallObserverBehaviour
    {
        [SerializeField] private GameObject particlesToPlayOnImpact;
        
        private Vector3 particleLocation;
        private Quaternion paticleRotation;
        
        private void Start()
        {
            AttachToFallingBallInScene();
        }
        
        public override void Notify(AbstractSubjectBehaviour _abstractSubjectBehaviour)
        {
            particleLocation = fallingBall.lastCollision.location;
            paticleRotation = fallingBall.lastCollision.rotation;
            paticleRotation *= Quaternion.Euler(0,0,90);

            GameObject collisionParticles = Instantiate(particlesToPlayOnImpact, particleLocation, paticleRotation, this.transform);
            ParticleSystem particles = collisionParticles.GetComponent<ParticleSystem>();
            
            particles.Play();
            Destroy(collisionParticles, particles.main.duration);
        }
    }
}