using System.Collections;
using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._003EventBus.PlatformerEventBus
{
    public class BallSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject ballToSpawn;
        [SerializeField, Range(0.1f,10f)] private float timeBetweenSpawns = 4f;
        private bool areWeSpawningBalls;

        private GameManagerEventBus gameManagerEventBus;

        private void Start()
        {
            areWeSpawningBalls = false;

            gameManagerEventBus = GameManagerEventBus.FindEventBusInScene();
            gameManagerEventBus.SubscribeActionToEvent(SpawnBall,PlatformerEvents.Start);
        }

        #region Subscribe and Unsubscribe to Event Bus at OnEnable/OnDisable
        
        private void OnEnable()
        {
            gameManagerEventBus = GameManagerEventBus.FindEventBusInScene();
            gameManagerEventBus.SubscribeActionToEvent(StartSpawningBalls,PlatformerEvents.Start);
        }

        private void OnDisable()
        {
            gameManagerEventBus.UnsubscribeActionFromEvent(StartSpawningBalls, PlatformerEvents.Start);
        }
        
        #endregion

        private void StartSpawningBalls()
        {
            areWeSpawningBalls = true;
            StartCoroutine(RepeatSpawningBalls());
        }

        private IEnumerator RepeatSpawningBalls()
        {
            while (areWeSpawningBalls)
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
