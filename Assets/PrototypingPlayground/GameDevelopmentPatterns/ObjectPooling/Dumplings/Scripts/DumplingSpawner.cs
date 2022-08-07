using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;
namespace PrototypingPlayground.GameDevelopmentPatterns.ObjectPooling.Dumplings
{
    public class DumplingSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject dumplingPrefab;
        [SerializeField] private Rect dumplingSpawnPerimeter = new Rect(new Vector2(0,0),new Vector2(10,10));
        private SpawnPerimeter spawnPerimeter;
        
        private void Awake()
        {
            Assert.IsNotNull(dumplingPrefab.GetComponent<Dumpling>());
        }
        
        void Start()
        {
            spawnPerimeter = new SpawnPerimeter(dumplingSpawnPerimeter, this.transform);
            Dumpling newDumpling = SpawnDumpling(spawnPerimeter.GetSpawnPointPosition(), spawnPerimeter.GetEndDestinationRotation());
            newDumpling.NavMeshAgent.SetDestination(spawnPerimeter.GetEndDestinationPosition());
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            
            // Get Center.
            Vector3 startLocation = new Vector3(transform.position.x + dumplingSpawnPerimeter.x,transform.position.y, transform.position.z + dumplingSpawnPerimeter.y);
            Gizmos.DrawSphere(startLocation, 0.3f);
            
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
        private Dumpling SpawnDumpling(Vector3 _spawnLocation, Quaternion _spawnRotation)
        {
                GameObject newDumpling = Instantiate(dumplingPrefab, _spawnLocation, _spawnRotation);
                Dumpling dumpling = newDumpling.GetComponent<Dumpling>();
                dumpling.NavMeshAgent.Warp(_spawnLocation);
                return dumpling;
        }
    }
}
