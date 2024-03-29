using UnityEngine;
using UnityEngine.Pool;
namespace PrototypingPlayground._001GameDevelopmentPatterns._005ObjectPooling.FallingObjects
{
    public class ObjectPoolFallingSphere : MonoBehaviour
    {
        public int maxPoolSize = 20;
        public int defaultPoolCapacity = 20;
        public GameObject fallingSphere;

        private IObjectPool<FallingSphere> pool;

        public IObjectPool<FallingSphere> Pool
        {
            get
            {
                if (pool == null)
                {
                    pool = new ObjectPool<FallingSphere>(CreatedPooledItem, 
                        OnTakeFromPool, 
                        OnReturnedToPool, 
                        OnDestroyPoolObject, 
                        true, 
                        defaultPoolCapacity,
                        maxPoolSize);
                }
                return pool;
            }
        }
        private void OnDestroyPoolObject(FallingSphere obj)
        {
            Destroy(obj.gameObject);
        }
        private void OnReturnedToPool(FallingSphere obj)
        {
            obj.transform.parent = this.transform;
            obj.gameObject.SetActive(false);
        }
        private void OnTakeFromPool(FallingSphere obj)
        {
            obj.gameObject.SetActive(true);
        }
        private FallingSphere CreatedPooledItem()
        {
            GameObject newGameObject = Instantiate(fallingSphere);
            FallingSphere newFallingSphere = newGameObject.GetComponentInChildren<FallingSphere>();
            newGameObject.name = "Falling Sphere";
            newFallingSphere.Pool = Pool;
            return newFallingSphere;
        }
    }
}
