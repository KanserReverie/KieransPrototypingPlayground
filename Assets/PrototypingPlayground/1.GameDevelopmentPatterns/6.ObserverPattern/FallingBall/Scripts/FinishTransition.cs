using PrototypingPlayground._1.GameDevelopmentPatterns._6.ObserverPattern.FallingBall.AbstractClasses;
using PrototypingPlayground.UsefulScripts;
using UnityEngine;
namespace PrototypingPlayground._1.GameDevelopmentPatterns._6.ObserverPattern.FallingBall
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
