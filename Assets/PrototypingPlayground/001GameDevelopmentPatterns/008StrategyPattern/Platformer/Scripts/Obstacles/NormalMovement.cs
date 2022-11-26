using System.Collections;
using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._008StrategyPattern.Platformer.Obstacles
{
    public class NormalMovement : MonoBehaviour, IObstacleMovement
    {

        public void Maneuver(Obstacle _obstacleToMove)
        {
            StartCoroutine(MoveObstacle(_obstacleToMove));
        }
        
        IEnumerator MoveObstacle(Obstacle _obstacle)
        {
            bool obstacleHasHitTheEnd = false;
            Vector3 originalStartPoint = _obstacle.transform.position;
            Vector3 endStartPoint = new Vector3(originalStartPoint.x - _obstacle.despawnDistance, originalStartPoint.y, originalStartPoint.z);
            float time = 0;
            
            while (!obstacleHasHitTheEnd)
            {
                _obstacle.transform.position = Vector3.Lerp(originalStartPoint, endStartPoint, time / _obstacle.secondsUntilDespawn);

                if (Vector3.Distance(_obstacle.transform.position, endStartPoint) <= 0.01f)
                {
                    obstacleHasHitTheEnd = true;
                }
                time += Time.deltaTime;
                
                yield return null;
            }
        }
    }
}
