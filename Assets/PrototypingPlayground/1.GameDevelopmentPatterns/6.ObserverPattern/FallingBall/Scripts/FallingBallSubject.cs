using PrototypingPlayground._1.GameDevelopmentPatterns._6.ObserverPattern.AbstractClasses;
using PrototypingPlayground._1.GameDevelopmentPatterns._6.ObserverPattern.FallingBall.AbstractClasses;
using UnityEngine;
namespace PrototypingPlayground._1.GameDevelopmentPatterns._6.ObserverPattern.FallingBall
{
    [RequireComponent(typeof(Rigidbody))]
    public class FallingBallSubject : AbstractSubjectBehaviour
    {
        public bool haveWeCollidedWithAnythingYet;
        public CollisionDetails lastCollision;
        
        private void Start()
        {
            lastCollision = null;
            haveWeCollidedWithAnythingYet = false;
        }

        private void OnCollisionEnter(Collision _collision)
        {
            if (lastCollision == null)
            {
                haveWeCollidedWithAnythingYet = true;
            }
            SaveLastCollision(_collision);
            NotifyObservers();
        }
        private void Update()
        {
        }
        private void SaveLastCollision(Collision _collision)
        {
            if (lastCollision == null)
            {
                lastCollision = new CollisionDetails(_collision);
            }
            else
            {
                CollisionDetails newCollision = new CollisionDetails(lastCollision, _collision);
                lastCollision = newCollision;
            }
        }

        private void OnTriggerEnter(Collider _collider)
        {
            AbstractTransitionObjectBehaviour transitionObject = _collider.gameObject.GetComponent<AbstractTransitionObjectBehaviour>();
            if (transitionObject != null)
            {
                transitionObject.TransitionMethod();
            }
        }
    }
}
