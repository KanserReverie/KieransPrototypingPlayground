using PrototypingPlayground._1.GameDevelopmentPatterns._6.ObserverPattern.AbstractClasses;
using UnityEngine;
namespace PrototypingPlayground._1.GameDevelopmentPatterns._6.ObserverPattern.FallingBall.AbstractClasses
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
