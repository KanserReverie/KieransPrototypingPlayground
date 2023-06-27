using PrototypingPlayground._001GameDevelopmentPatterns._006ObserverPattern.FallingBall.AbstractClasses;
using PrototypingPlayground.UsefulScripts;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
namespace PrototypingPlayground._001GameDevelopmentPatterns._006ObserverPattern.FallingBall
{
    public class GroundTransition : AbstractTransitionObjectBehaviour
    {
        [SerializeField] private Scene sceneToTransition;
        
        public override void TransitionMethod()
        {
            SceneManager.LoadScene(sceneToTransition.name);
        }
    }
}
