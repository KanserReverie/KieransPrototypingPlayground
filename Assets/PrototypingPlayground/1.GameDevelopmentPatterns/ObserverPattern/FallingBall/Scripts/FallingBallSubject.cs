using PrototypingPlayground._1.GameDevelopmentPatterns.ObserverPattern.AbstractClasses;
using UnityEngine;
using UnityEngine.Events;
namespace PrototypingPlayground._1.GameDevelopmentPatterns.ObserverPattern.FallingBall
{
    [RequireComponent(typeof(Rigidbody))]
    public class FallingBallSubject : AbstractSubjectBehaviour
    {
        public bool haveWeCollidedWithAnythingYet;
        public CollisionDetails lastCollision;
        
        public UnityEvent lastTransitionObjectActionToRun;
        
        private void Start()
        {
            lastCollision = null;
            haveWeCollidedWithAnythingYet = false;
            lastTransitionObjectActionToRun = null;
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
        
        private void SaveLastCollision(Collision _collision)
        {
            if (lastCollision == null)
            {
                lastCollision = new CollisionDetails(_collision);
            }
            else
            {
                lastCollision = new CollisionDetails(lastCollision, _collision);
            }
        }
    }
}
