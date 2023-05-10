using System.Collections;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._008StrategyPattern.FighterDrones.DroneStrategies
{
    [SuppressMessage("ReSharper", "IteratorNeverReturns")]
    public class DiagonalManeuver : MonoBehaviour, IDroneStrategy
    {

        public void ImplementStrategy(Drone drone)
        {
            StartCoroutine(DiagonalMove(drone));
        }
        IEnumerator DiagonalMove(Drone drone)
        {
            float time;
            bool isReverse = false;
            float speed = drone.speed;
            
            MovementDirection direction = Random.value >= 0.5f ? MovementDirection.LeftBack : MovementDirection.RightBack;
            
            Vector3 startPosition = drone.transform.position;
            Vector3 endPosition = startPosition;
            float shortSideMovement = drone.diagonalDistance / Mathf.Sqrt(2f);

            if (direction == MovementDirection.RightBack)
                endPosition.x += shortSideMovement;
            else
                endPosition.x -= shortSideMovement;
            
            endPosition.z += shortSideMovement;

            while (true)
            {
                time = 0;
                Vector3 start = drone.transform.position;
                Vector3 end =
                    (isReverse) ? startPosition : endPosition;

                while (time < speed)
                {
                    drone.transform.position = Vector3.Lerp(start, end, time / speed);
                    time += Time.deltaTime;
                    yield return null;
                }
                yield return new WaitForSeconds(1);
                isReverse = !isReverse;
            }
        }
        
        private enum MovementDirection { LeftBack, RightBack }
        
    }
}
