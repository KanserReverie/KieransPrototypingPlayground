using UnityEngine;
using UnityEngine.Pool;
namespace PrototypingPlayground._001GameDevelopmentPatterns._005ObjectPooling.Drones
{
    public class DroneObjectPool : MonoBehaviour
    {
        public int maximumPoolSize = 10;
        public int stackDefaultCapacity = 10;
        private IObjectPool<Drone> pool;
        
        public IObjectPool<Drone> Pool
        {
            get
            {
                if (pool == null)
                {
                    pool = new ObjectPool<Drone>(
                        CreatedPooledItem,
                        OnTakeFromPool,
                        OnReturnedToPool,
                        OnDestroyPoolObject,
                        true,
                        stackDefaultCapacity,
                        maximumPoolSize);
                }
                return pool;
            }
        }
        private Drone CreatedPooledItem()
        {
            GameObject droneGameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);

            Drone newDrone = droneGameObject.AddComponent<Drone>();

            droneGameObject.name = "Drone";
            newDrone.Pool = Pool;
            droneGameObject.transform.parent = this.transform;
            return newDrone;
        }
        
        private void OnReturnedToPool(Drone drone)
        {
            drone.gameObject.SetActive(false);
        }
        
        private void OnTakeFromPool(Drone drone)
        {
            drone.gameObject.SetActive(true);
        }
        
        private void OnDestroyPoolObject(Drone drone)
        {
            Destroy(drone.gameObject);
        }
    }
}
