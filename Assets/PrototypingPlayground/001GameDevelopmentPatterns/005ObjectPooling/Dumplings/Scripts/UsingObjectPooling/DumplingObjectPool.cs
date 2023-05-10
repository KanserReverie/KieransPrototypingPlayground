using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Pool;
namespace PrototypingPlayground._001GameDevelopmentPatterns._005ObjectPooling.Dumplings.UsingObjectPooling
{
    public class DumplingObjectPool : MonoBehaviour
    {
        public int maxNumberOfPooledDumplings;
        public int defaultNumberOfPooledDumplings;
        [SerializeField] private GameObject dumplingPrefab;

        private void Awake()
        {
            Assert.IsNotNull(dumplingPrefab);
            Assert.IsNotNull(dumplingPrefab.GetComponent<DumplingUsingObjectPool>());
        }
        
        private IObjectPool<DumplingUsingObjectPool> pool;
        public IObjectPool<DumplingUsingObjectPool> Pool
        {
            get
            {
                if (pool == null)
                {
                    pool = new ObjectPool<DumplingUsingObjectPool>(
                        OnCreatePooledDumpling, 
                        OnTakeDumplingFromPool,
                        OnReturnedDumplingToPool,
                        OnDestroyedPooledDumpling, true, defaultNumberOfPooledDumplings, maxNumberOfPooledDumplings);
                }
                return pool;
            }
        }
        private DumplingUsingObjectPool OnCreatePooledDumpling()
        {
            GameObject newDumplingGameObject = Instantiate(dumplingPrefab, this.transform, true);
            newDumplingGameObject.name = $"{dumplingPrefab.name}";
            DumplingUsingObjectPool newDumplingWithoutObjectPool = newDumplingGameObject.GetComponentInChildren<DumplingUsingObjectPool>();
            newDumplingWithoutObjectPool.DumplingPool = Pool;
            return newDumplingWithoutObjectPool;
        }
        private void OnTakeDumplingFromPool(DumplingUsingObjectPool dumplingWithoutObjectPool)
        {
            dumplingWithoutObjectPool.gameObject.SetActive(true);
        }
        private void OnReturnedDumplingToPool(DumplingUsingObjectPool dumplingWithoutObjectPool)
        {
            dumplingWithoutObjectPool.gameObject.SetActive(false);
        }
        private void OnDestroyedPooledDumpling(DumplingUsingObjectPool dumplingWithoutObjectPool)
        {
            Destroy(dumplingWithoutObjectPool.gameObject);
        }
    }
}
