using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;
namespace PrototypingPlayground._001GameDevelopmentPatterns._005ObjectPooling.Dumplings.WithoutObjectPooling
{
    public class DumplingSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject dumplingPrefab;
        [SerializeField] private Rect dumplingSpawnPerimeter = new Rect(new Vector2(0,0),new Vector2(10,10));
        private SpawnPerimeter spawnPerimeter;
        
        private void Awake()
        {
            Assert.IsNotNull(dumplingPrefab.GetComponent<DumplingWithoutObjectPool>());
        }
        
        void Start()
        {
            spawnPerimeter = new SpawnPerimeter(dumplingSpawnPerimeter, this.transform);
            DumplingWithoutObjectPool newDumplingWithoutObjectPool = SpawnDumpling(spawnPerimeter.GetSpawnPointPosition(), spawnPerimeter.GetSpawnPointRotation());
            newDumplingWithoutObjectPool.NavMeshAgent.SetDestination(spawnPerimeter.GetEndDestinationPosition());
        }
        private void OnGUI()
        {
            if (GUILayout.Button("Spawn Dumpling"))
            {
                spawnPerimeter.GenerateRandomSpawnPointAndDestination();
                DumplingWithoutObjectPool newDumplingWithoutObjectPool = SpawnDumpling(spawnPerimeter.GetSpawnPointPosition(), spawnPerimeter.GetSpawnPointRotation());
                newDumplingWithoutObjectPool.NavMeshAgent.SetDestination(spawnPerimeter.GetEndDestinationPosition());
            }
        }
        
        private DumplingWithoutObjectPool SpawnDumpling(Vector3 spawnLocation, Quaternion spawnRotation)
        {
            GameObject newDumpling = Instantiate(dumplingPrefab, spawnLocation, spawnRotation);
            DumplingWithoutObjectPool dumplingWithoutObjectPool = newDumpling.GetComponent<DumplingWithoutObjectPool>();
            dumplingWithoutObjectPool.NavMeshAgent.Warp(spawnLocation);
            return dumplingWithoutObjectPool;
        }
        
#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            
            // Get Center.
            Vector3 startLocation = new Vector3(transform.position.x + dumplingSpawnPerimeter.x,transform.position.y, transform.position.z + dumplingSpawnPerimeter.y);
            
            // Get all Corners
            Vector3[] allCorners = new Vector3[4];

            allCorners[0] = startLocation + new Vector3(dumplingSpawnPerimeter.width / 2, 0, dumplingSpawnPerimeter.height / 2);
            allCorners[1] = startLocation + new Vector3(-dumplingSpawnPerimeter.width / 2, 0, dumplingSpawnPerimeter.height / 2);
            allCorners[2] = startLocation + new Vector3(-dumplingSpawnPerimeter.width / 2, 0, -dumplingSpawnPerimeter.height / 2);
            allCorners[3] = startLocation + new Vector3(dumplingSpawnPerimeter.width / 2, 0, -dumplingSpawnPerimeter.height / 2);
            for (int i = 0; i < allCorners.Length; i++)
            {
                Gizmos.DrawSphere(allCorners[i], 0.2f);
            }
            int thickness = 4;
            Handles.DrawBezier(allCorners[0],allCorners[1],allCorners[0],allCorners[1], Color.yellow,null,thickness);
            Handles.DrawBezier(allCorners[1],allCorners[2],allCorners[1],allCorners[2], Color.yellow,null,thickness);
            Handles.DrawBezier(allCorners[2],allCorners[3],allCorners[2],allCorners[3], Color.yellow,null,thickness);
            Handles.DrawBezier(allCorners[3],allCorners[0],allCorners[3],allCorners[0], Color.yellow,null,thickness);
        }
#endif
    }
}
