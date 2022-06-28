using System;
using System.Collections;
using UnityEngine;
namespace PrototypingPlayground.EventBus.PlatformerEventBus
{
    public class BallSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject ballToSpawn;
        [SerializeField, Range(0.1f,10f)] private float timeBetweenSpawns = 4f;
        private bool _areWeSpawningBalls;

        private PlatformerGameManagerEventBus _platformerGameManagerEventBus;

        private void Start()
        {
            _areWeSpawningBalls = false;

            _platformerGameManagerEventBus = PlatformerGameManagerEventBus.FindEventBusInScene();
            
            if(_platformerGameManagerEventBus != null)
                _platformerGameManagerEventBus.SubscribeActionToEvent(SpawnBall,PlatformerEvents.START);
        }

        #region Subscribe and Unsubscribe to Event Bus at OnEnable/OnDisable
        
        private void OnEnable()
        {
            _platformerGameManagerEventBus = PlatformerGameManagerEventBus.FindEventBusInScene();
            _platformerGameManagerEventBus.SubscribeActionToEvent(StartSpawningBalls,PlatformerEvents.START);
        }

        private void OnDisable()
        {
            _platformerGameManagerEventBus.UnsubscribeActionFromEvent(StartSpawningBalls, PlatformerEvents.START);
        }
        
        #endregion

        private void StartSpawningBalls()
        {
            _areWeSpawningBalls = true;
            StartCoroutine(RepeatSpawningBalls());
        }

        private IEnumerator RepeatSpawningBalls()
        {
            while (_areWeSpawningBalls)
            {
                yield return new WaitForSeconds(timeBetweenSpawns);
                SpawnBall();
            }
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
