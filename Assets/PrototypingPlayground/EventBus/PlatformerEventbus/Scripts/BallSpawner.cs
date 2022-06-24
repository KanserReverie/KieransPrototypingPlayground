using System;
using UnityEngine;
namespace PrototypingPlayground.EventBus.PlatformerEventBus
{
    public class BallSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject ballToSpawn;

        private PlatformerGameManagerEventBus _platformerGameManagerEventBus;

        private void Start()
        {
            if(_platformerGameManagerEventBus == null)
                _platformerGameManagerEventBus = FindObjectOfType<PlatformerGameManagerEventBus>();
            
            if(_platformerGameManagerEventBus == null)
                Debug.Log("Please add a PlatformerGameManagerEventBus to Scene!!");
            else
                _platformerGameManagerEventBus.SubscribeActionToEvent(SpawnBall,PlatformerEvents.SPAWNBALLS);
        }

        private void OnEnable()
        {
            _platformerGameManagerEventBus = FindObjectOfType<PlatformerGameManagerEventBus>();
            if (_platformerGameManagerEventBus == null)
            {
                Debug.Log("Please add a _platformerGameManagerEventBus to Scene");
            }
            _platformerGameManagerEventBus.SubscribeActionToEvent(SpawnBall,PlatformerEvents.SPAWNBALLS);
        }

        private void OnDisable()
        {
            _platformerGameManagerEventBus.UnsubscribeActionFromEvent(SpawnBall, PlatformerEvents.SPAWNBALLS);
        }

        private void SpawnBall()
        {
            if (ballToSpawn == null)
                return;
            var thisTransform = transform;
            Instantiate(ballToSpawn, thisTransform.position, thisTransform.rotation);
        }
    }
}
