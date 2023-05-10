using UnityEngine;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace PrototypingPlayground._001GameDevelopmentPatterns._008StrategyPattern.FighterDrones.DroneStrategies
{
    [SuppressMessage("ReSharper", "IteratorNeverReturns")]
    public class BoppingManeuver : MonoBehaviour, IDroneStrategy
    {
        public void ImplementStrategy(Drone drone)
        {
            StartCoroutine(Bopple(drone));
        }

        IEnumerator Bopple(Drone drone)
        {
            float time;
            bool isReverse = false;
            float speed = drone.speed;
            Vector3 startPosition = drone.transform.position;
            Vector3 endPosition = startPosition;
            endPosition.y = drone.maxHeight;

            while (true)
            {
                time = 0;
                Vector3 start = drone.transform.position;
                Vector3 end =
                    (isReverse) ? startPosition : endPosition;

                while (time < speed)
                {
                    drone.transform.position =
                        Vector3.Lerp(start, end, time / speed);
                    time += Time.deltaTime;
                    yield return null;
                }

                yield return new WaitForSeconds(1);
                isReverse = !isReverse;
            }
        }
    }
}
