using UnityEngine;
namespace PrototypingPlayground.GameDevelopmentPatterns.ObjectPooling.Dumplings
{
    public class SpawnPerimeter
    {
            private Vector3[] corners = new Vector3[4];
            private Vector3 spawnPointPosition;
            private Quaternion spawnPointRotation;
            private Vector3 endDestinationPosition;
            
            public Vector3 GetSpawnPointPosition() => spawnPointPosition;
            public Quaternion GetSpawnPointRotation() => spawnPointRotation;
            public Vector3 GetEndDestinationPosition() => endDestinationPosition;
            
            public SpawnPerimeter(Rect _perimeterRect, Transform _spawnTransform)
            {
                Vector3 startLocation = new Vector3(_spawnTransform.position.x + _perimeterRect.x, _spawnTransform.position.y, _spawnTransform.position.z + _perimeterRect.y);
                
                // Get all Corners
                corners[0] = startLocation + new Vector3(_perimeterRect.width / 2, 0, _perimeterRect.height / 2);
                corners[1] = startLocation + new Vector3(-_perimeterRect.width / 2, 0, _perimeterRect.height / 2);
                corners[2] = startLocation + new Vector3(-_perimeterRect.width / 2, 0, -_perimeterRect.height / 2);
                corners[3] = startLocation + new Vector3(_perimeterRect.width / 2, 0, -_perimeterRect.height / 2);
                
                GenerateRandomSpawnPointAndDestination();
            }
            public void GenerateRandomSpawnPointAndDestination()
            {
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

            private Vector3 GenerateRandomPoint(Vector3 _point1, Vector3 _point2)
            {
                return new Vector3(Random.Range(_point1.x, _point2.x), Random.Range(_point1.y , _point2.y), Random.Range(_point1.z , _point2.z));
            }
    }
}
