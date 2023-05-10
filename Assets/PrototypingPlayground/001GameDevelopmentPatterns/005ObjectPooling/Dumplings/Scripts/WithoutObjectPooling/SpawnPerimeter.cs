using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._005ObjectPooling.Dumplings.WithoutObjectPooling
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
            
        public SpawnPerimeter(Rect perimeterRect, Transform spawnTransform)
        {
            Vector3 startLocation = new Vector3(spawnTransform.position.x + perimeterRect.x, spawnTransform.position.y, spawnTransform.position.z + perimeterRect.y);
                
            // Get all Corners
            corners[0] = startLocation + new Vector3(perimeterRect.width / 2, 0, perimeterRect.height / 2);
            corners[1] = startLocation + new Vector3(-perimeterRect.width / 2, 0, perimeterRect.height / 2);
            corners[2] = startLocation + new Vector3(-perimeterRect.width / 2, 0, -perimeterRect.height / 2);
            corners[3] = startLocation + new Vector3(perimeterRect.width / 2, 0, -perimeterRect.height / 2);
                
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

        private Vector3 GenerateRandomPoint(Vector3 point1, Vector3 point2)
        {
            return new Vector3(Random.Range(point1.x, point2.x), Random.Range(point1.y , point2.y), Random.Range(point1.z , point2.z));
        }
    }
}
