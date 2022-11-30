using System;
using PrototypingPlayground.UsefulScripts;
using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._008StrategyPattern.Platformer.Obstacles
{
    public class Obstacle : MonoBehaviour
    {
        // Movement parameters
        public float despawnDistance = 20;
        [Header("Normal Movement")]
        public float secondsUntilDespawnNormal = 4.0f;
        [Header("Fast Movement")]
        public float secondsUntilDespawnFast = 1.0f;

        public void StartMovement(IObstacleMovement _movement)
        {
            _movement.Maneuver(this);
        }

        private void OnTriggerEnter(Collider _collider)
        {
            if (_collider.GetComponentInChildren<PlatformingCharacterController>())
            {
                CommonlyUsedStaticMethods.ResetCurrentScene();
            }
        }
    }
}
