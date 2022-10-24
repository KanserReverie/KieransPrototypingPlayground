using System.Collections;
using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._003EventBus.PlatformerEventBus
{
    public class BallSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject ballToSpawn;
        [SerializeField, Range(0.1f,10f)] private float timeBetweenSpawns = 4f;
        private bool _areWeSpawningBalls;

        private GameManagerEventBus _gameManagerEventBus;

        private void Start()
        {
            _areWeSpawningBalls = false;

            _gameManagerEventBus = GameManagerEventBus.FindEventBusInScene();
            _gameManagerEventBus.SubscribeActionToEvent(SpawnBall,PlatformerEvents.START);
        }

        #region Subscribe and Unsubscribe to Event Bus at OnEnable/OnDisable
        
        private void OnEnable()
        {
            _gameManagerEventBus = GameManagerEventBus.FindEventBusInScene();
            _gameManagerEventBus.SubscribeActionToEvent(StartSpawningBalls,PlatformerEvents.START);
        }

        private void OnDisable()
        {
            _gameManagerEventBus.UnsubscribeActionFromEvent(StartSpawningBalls, PlatformerEvents.START);
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
            Transform thisTransform = transform;
            GameObject ballMade = Instantiate(ballToSpawn, thisTransform.position, thisTransform.rotation);
            ballMade.gameObject.AddComponent(typeof(BallObstacle));
        }
    }
}
