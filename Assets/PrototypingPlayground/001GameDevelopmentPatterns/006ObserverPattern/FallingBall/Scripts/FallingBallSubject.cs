using PrototypingPlayground._001GameDevelopmentPatterns._006ObserverPattern.FallingBall.AbstractClasses;
using PrototypingPlayground._001GameDevelopmentPatterns._006ObserverPattern.GenericObserverPattern;
using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._006ObserverPattern.FallingBall
{
    [RequireComponent(typeof(Rigidbody))]
    public class FallingBallSubject : AbstractSubjectBehaviour
    {
        public bool haveWeCollidedWithAnythingYet;
        public CollisionDetails LastCollision;
        
        private void Start()
        {
            LastCollision = null;
            haveWeCollidedWithAnythingYet = false;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (LastCollision == null)
            {
                haveWeCollidedWithAnythingYet = true;
            }
            SaveLastCollision(collision);
            NotifyObservers();
        }

        private void SaveLastCollision(Collision collision)
        {
            if (LastCollision == null)
            {
                LastCollision = new CollisionDetails(collision);
            }
            else
            {
                CollisionDetails newCollision = new CollisionDetails(LastCollision, collision);
                LastCollision = newCollision;
            }
        }

        private void OnTriggerEnter(Collider collider)
        {
            AbstractTransitionObjectBehaviour transitionObject = collider.gameObject.GetComponent<AbstractTransitionObjectBehaviour>();
            if (transitionObject != null)
            {
                transitionObject.TransitionMethod();
            }
        }
    }
}
