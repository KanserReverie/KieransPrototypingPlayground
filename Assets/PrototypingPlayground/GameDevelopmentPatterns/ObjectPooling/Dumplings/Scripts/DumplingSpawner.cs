using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;
namespace PrototypingPlayground.GameDevelopmentPatterns.ObjectPooling.Dumplings
{
    public class DumplingSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject dumplingPrefab;
        [SerializeField] private Transform spawnLocation;
        [SerializeField] private Transform spawnDestination;
        private void Awake()
        {
            Assert.IsNotNull(dumplingPrefab.GetComponent<Dumpling>());
            Assert.IsNotNull(spawnLocation);
            Assert.IsNotNull(spawnDestination);
        }
        
        void Start()
        {
            SpawnDumpling(spawnLocation);
        }
        private void SpawnDumpling(Transform _spawnLocation)
        {
                NavMeshHit navMeshHit;
                NavMesh.SamplePosition(_spawnLocation.position, out navMeshHit, 2f, 0);
                GameObject newDumpling = Instantiate(dumplingPrefab, _spawnLocation.position, _spawnLocation.rotation);
                Dumpling dumpling = newDumpling.GetComponent<Dumpling>();
                dumpling.NavMeshAgent.Warp(_spawnLocation.position);
                dumpling.NavMeshAgent.SetDestination(spawnDestination.position);
        }
    }
}
