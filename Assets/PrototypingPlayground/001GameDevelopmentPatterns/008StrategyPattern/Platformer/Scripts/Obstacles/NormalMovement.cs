using System.Collections;
using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._008StrategyPattern.Platformer.Obstacles
{
    public class NormalMovement : MonoBehaviour, IObstacleMovement
    {
        public void Maneuver(Obstacle obstacleToMove)
        {
            StartCoroutine(MoveObstacle(obstacleToMove));
        }
        
        IEnumerator MoveObstacle(Obstacle obstacle)
        {
            bool obstacleHasHitTheEnd = false;
            Vector3 originalStartPoint = obstacle.transform.position;
            Vector3 endStartPoint = new Vector3(originalStartPoint.x - obstacle.despawnDistance, originalStartPoint.y, originalStartPoint.z);
            float time = 0;
            
            while (!obstacleHasHitTheEnd)
            {
                obstacle.transform.position = Vector3.Lerp(originalStartPoint, endStartPoint, time / obstacle.secondsUntilDespawnNormal);

                if (Vector3.Distance(obstacle.transform.position, endStartPoint) <= 0.01f)
                {
                    obstacleHasHitTheEnd = true;
                }
                time += Time.deltaTime;
                yield return null;
            }
            Destroy(this.gameObject);
        }
    }
}
