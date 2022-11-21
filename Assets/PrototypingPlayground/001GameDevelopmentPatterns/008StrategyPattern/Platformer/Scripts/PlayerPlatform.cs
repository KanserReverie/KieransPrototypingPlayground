using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._008StrategyPattern.Platformer
{
    public class PlayerPlatform : MonoBehaviour
    {
        [SerializeField] private float lifecycleLength = 2.1f;

        public void StartLifeCycle(IPlayerPlatformLifecycle _platformLifecycle)
        {
            _platformLifecycle.StartLifecycle(this);
        }
    }
}
