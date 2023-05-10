using UnityEngine;
using UnityEngine.Assertions;

namespace PrototypingPlayground._001GameDevelopmentPatterns._008StrategyPattern.Platformer.Obstacles
{
    public class ObstacleSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject obstaclePrefab;
        [SerializeField] private Vector3 spawnLocation = Vector3.zero;
        [SerializeField, Range(0.1f, 10)] private float spawnRate = 4;
        private float currentSpawnTimer;
        [Header("Debug.Log")]
        [SerializeField] private bool debugLogThisComponent;
        

        private void Start()
        {
            Assert.IsNotNull(obstaclePrefab);
            Assert.IsNotNull(obstaclePrefab.GetComponentInChildren<Obstacle>());
            if (debugLogThisComponent) Debug.Log($"Start Spawning Obstacles");
            currentSpawnTimer = spawnRate;
        }

        private void Update()
        {
            if (currentSpawnTimer <= 0) SpawnRandomObstacle();
            CountDownSpawnTimer();
        }
        
        private void CountDownSpawnTimer()
        {
            if (currentSpawnTimer > 0)
            {
                currentSpawnTimer -= Time.deltaTime;
            }
            else
            {
                currentSpawnTimer = spawnRate;
            }
        }

        private void SpawnRandomObstacle()
        {
            if (debugLogThisComponent) Debug.Log($"Spawn an Obstacle");
            GameObject spawnedObstacle = Instantiate(obstaclePrefab, spawnLocation, transform.rotation);
            IObstacleMovement obstacleMovement = AddRandomMovement(spawnedObstacle);
            Obstacle obstacleComponent = spawnedObstacle.GetComponentInChildren<Obstacle>();
            obstacleComponent.StartMovement(obstacleMovement);
        }
        
        private IObstacleMovement AddRandomMovement(GameObject spawnedObstacle)
        {
            int obstacleToSpawn = Random.Range(0, 2);
            if (obstacleToSpawn == 0)
            {
                if (debugLogThisComponent) Debug.Log($"AddFastMovement to Obstacle");
                return spawnedObstacle.AddComponent<FastMovement>();
            }
            else
            {
                if (debugLogThisComponent) Debug.Log($"AddNormalMovement to Obstacle");
                return spawnedObstacle.AddComponent<NormalMovement>();
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(spawnLocation, 0.5f);
        }
    }
}
