using PrototypingPlayground._001GameDevelopmentPatterns._006ObserverPattern.FallingBall.AbstractClasses;
using PrototypingPlayground.UsefulScripts;
using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._006ObserverPattern.FallingBall
{
    public class FinishTransition : AbstractTransitionObjectBehaviour
    {
        public override void TransitionMethod()
        {
            Debug.Log("Congratulations Course Complete - Brought to you by the Observer Pattern");
            CommonlyUsedStaticMethods.QuitGame();
        }
    }
}
