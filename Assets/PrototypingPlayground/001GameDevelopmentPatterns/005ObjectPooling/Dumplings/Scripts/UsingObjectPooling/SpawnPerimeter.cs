using UnityEditor;
using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._005ObjectPooling.Dumplings.UsingObjectPooling
{
    public class SpawnPerimeter : MonoBehaviour
    {
        [SerializeField] private Rect dumplingSpawnPerimeter = new Rect(new Vector2(0, 0), new Vector2(10, 10));
        
        private Vector3[] corners = new Vector3[4];
        private Vector3 spawnPointPosition;
        private Quaternion spawnPointRotation;
        private Vector3 endDestinationPosition;

        public Vector3 GetSpawnPointPosition() => spawnPointPosition;
        public Quaternion GetSpawnPointRotation() => spawnPointRotation;
        public Vector3 GetEndDestinationPosition() => endDestinationPosition;

        public void GenerateRandomSpawnPointAndDestination()
        {
            GetSpawnPerimeter(dumplingSpawnPerimeter, this.gameObject.transform);
            int randomSide = Random.Range(1, 5);
            switch (randomSide)
            {
                case 1:
                    spawnPointPosition = GenerateRandomPoint(corners[0], corners[1]);
                    endDestinationPosition = new Vector3(-spawnPointPosition.x, spawnPointPosition.y, -spawnPointPosition.z);
                    break;
                case 2:
                    spawnPointPosition = GenerateRandomPoint(corners[1], corners[2]);
                    endDestinationPosition = new Vector3(-spawnPointPosition.x, spawnPointPosition.y, -spawnPointPosition.z);
                    break;
                case 3:
                    spawnPointPosition = GenerateRandomPoint(corners[2], corners[3]);
                    endDestinationPosition = new Vector3(-spawnPointPosition.x, spawnPointPosition.y, -spawnPointPosition.z);
                    break;
                case 4:
                    spawnPointPosition = GenerateRandomPoint(corners[3], corners[0]);
                    endDestinationPosition = new Vector3(-spawnPointPosition.x, spawnPointPosition.y, -spawnPointPosition.z);
                    break;
                default:
                    Debug.Log("No valid side");
                    break;
            }
            spawnPointRotation = Quaternion.FromToRotation(spawnPointPosition, endDestinationPosition);
        }

        private void GetSpawnPerimeter(Rect _dumplingSpawnPerimeter, Transform _transform)
        {
            Vector3 startLocation = new Vector3(_transform.position.x + _dumplingSpawnPerimeter.x, _transform.position.y, _transform.position.z + _dumplingSpawnPerimeter.y);

            for (int i = 0; i < corners.Length; i++)
            {
                corners[i] = new Vector3();
            }
            // Get all Corners
            corners[0] = startLocation + new Vector3(_dumplingSpawnPerimeter.width / 2, 0, _dumplingSpawnPerimeter.height / 2);
            corners[1] = startLocation + new Vector3(-_dumplingSpawnPerimeter.width / 2, 0, _dumplingSpawnPerimeter.height / 2);
            corners[2] = startLocation + new Vector3(-_dumplingSpawnPerimeter.width / 2, 0, -_dumplingSpawnPerimeter.height / 2);
            corners[3] = startLocation + new Vector3(_dumplingSpawnPerimeter.width / 2, 0, -_dumplingSpawnPerimeter.height / 2);
        }
        
        private Vector3 GenerateRandomPoint(Vector3 _point1, Vector3 _point2)
        {
            return new Vector3(Random.Range(_point1.x, _point2.x), Random.Range(_point1.y, _point2.y), Random.Range(_point1.z, _point2.z));
        }
        
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

    }
}
