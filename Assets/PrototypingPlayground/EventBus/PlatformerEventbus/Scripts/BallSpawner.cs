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

            FindEventBusInScene();
            
            if(_platformerGameManagerEventBus != null)
                _platformerGameManagerEventBus.SubscribeActionToEvent(SpawnBall,PlatformerEvents.SPAWN_BALLS);
        }

        #region Subscribe and Unsubscribe to Event Bus at OnEnable/OnDisable
        
        private void OnEnable()
        {
            FindEventBusInScene();
            _platformerGameManagerEventBus.SubscribeActionToEvent(StartSpawningBalls,PlatformerEvents.SPAWN_BALLS);
        }

        private void OnDisable()
        {
            _platformerGameManagerEventBus.UnsubscribeActionFromEvent(StartSpawningBalls, PlatformerEvents.SPAWN_BALLS);
        }
        
        #endregion

        private void FindEventBusInScene()
        {
            if(_platformerGameManagerEventBus == null)
                _platformerGameManagerEventBus = FindObjectOfType<PlatformerGameManagerEventBus>();
            
            if(_platformerGameManagerEventBus == null)
                Debug.Log("Please add a PlatformerGameManagerEventBus to Scene!!");
        }
        
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
