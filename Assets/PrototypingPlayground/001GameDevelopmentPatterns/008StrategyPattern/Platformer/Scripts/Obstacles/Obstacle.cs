using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._008StrategyPattern.Platformer.Obstacles
{
    public class Obstacle : MonoBehaviour
    {
        // Movement parameters
        public float secondsUntilDespawn = 1.0f;
        public float despawnDistance = 4;

        public void StartMovement(IObstacleMovement _movement)
        {
            _movement.Maneuver(this);
        }
    }
}
