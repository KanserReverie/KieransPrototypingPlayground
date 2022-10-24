using UnityEngine;
using UnityEngine.Assertions;
namespace PrototypingPlayground._001GameDevelopmentPatterns._005ObjectPooling.Dumplings.UsingObjectPooling
{
    public class DumplingObjectPoolSpawner : MonoBehaviour
    {
        [SerializeField] private DumplingObjectPool dumplingObjectPool;
        [SerializeField] private SpawnPerimeter spawnPerimeter;

        private void Awake()
        {
            Assert.IsNotNull(dumplingObjectPool);
            Assert.IsNotNull(spawnPerimeter);
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Spawn Dumpling"))
            {
                SpawnDumpling();
            }
        }
        private void SpawnDumpling()
        {
            spawnPerimeter.GenerateRandomSpawnPointAndDestination();
            Dumpling_UsingObjectPool spawnedDumpling = dumplingObjectPool.Pool.Get();
            spawnedDumpling.Initialize(spawnPerimeter.GetEndDestinationPosition(),spawnPerimeter.GetSpawnPointPosition(), spawnPerimeter.GetSpawnPointRotation()); 
            spawnedDumpling.NavMeshAgent.SetDestination(spawnPerimeter.GetEndDestinationPosition());
        }
    }
}
