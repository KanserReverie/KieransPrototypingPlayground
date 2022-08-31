using UnityEngine;
using UnityEngine.Pool;
namespace PrototypingPlayground._1.GameDevelopmentPatterns._5.ObjectPooling.FallingObjects
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
        private void OnDestroyPoolObject(FallingSphere _obj)
        {
            Destroy(_obj.gameObject);
        }
        private void OnReturnedToPool(FallingSphere _obj)
        {
            _obj.transform.parent = this.transform;
            _obj.gameObject.SetActive(false);
        }
        private void OnTakeFromPool(FallingSphere _obj)
        {
            _obj.gameObject.SetActive(true);
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
