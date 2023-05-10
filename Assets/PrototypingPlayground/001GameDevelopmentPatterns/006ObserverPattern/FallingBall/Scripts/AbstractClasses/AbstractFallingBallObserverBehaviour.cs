using PrototypingPlayground._001GameDevelopmentPatterns._006ObserverPattern.GenericObserverPattern;
using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._006ObserverPattern.FallingBall.AbstractClasses
{
    public abstract class AbstractFallingBallObserverBehaviour : AbstractObserverBehaviour
    {
        protected FallingBallSubject FallingBall;
        
        public abstract override void Notify(AbstractSubjectBehaviour abstractSubjectBehaviour);
        
        protected void AttachToFallingBallInScene()
        {
            FallingBall = FindObjectOfType<FallingBallSubject>();

            if (!FallingBall)
            {
                Debug.Log("No falling ball in scene. \n Pausing Game;");
                Debug.Break();
            }
            
            FallingBall.AttachObserver(this);
        }
    }
}
