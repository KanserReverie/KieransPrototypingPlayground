using PrototypingPlayground._1.GameDevelopmentPatterns.ObserverPattern.FallingBall.AbstractClasses;
using PrototypingPlayground.UsefulScripts;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

namespace PrototypingPlayground._1.GameDevelopmentPatterns.ObserverPattern.FallingBall
{
    public class GroundTransition : AbstractTransitionObjectBehaviour
    {
        [SerializeField] private SceneReference sceneToTransition;

        private void Awake()
        {
            Assert.IsNotNull(sceneToTransition);
        }
        
        public override void TransitionMethod()
        {
            SceneManager.LoadScene(sceneToTransition.SceneName);
        }
    }
}
