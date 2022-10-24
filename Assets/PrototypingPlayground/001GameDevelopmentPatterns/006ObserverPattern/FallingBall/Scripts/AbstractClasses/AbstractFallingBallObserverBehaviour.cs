using PrototypingPlayground._001GameDevelopmentPatterns._006ObserverPattern.AbstractClasses;
using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._006ObserverPattern.FallingBall.AbstractClasses
{
    public abstract class AbstractFallingBallObserverBehaviour : AbstractObserverBehaviour
    {
        protected FallingBallSubject fallingBall;
        
        public abstract override void Notify(AbstractSubjectBehaviour _abstractSubjectBehaviour);
        
        protected void AttachToFallingBallInScene()
        {
            fallingBall = FindObjectOfType<FallingBallSubject>();

            if (!fallingBall)
            {
                Debug.Log("No falling ball in scene. \n Pausing Game;");
                Debug.Break();
            }
            
            fallingBall.AttachObserver(this);
        }
    }
}
