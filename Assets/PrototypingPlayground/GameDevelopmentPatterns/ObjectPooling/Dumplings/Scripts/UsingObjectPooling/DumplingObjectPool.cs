using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Pool;
namespace PrototypingPlayground.GameDevelopmentPatterns.ObjectPooling.Dumplings.UsingObjectPooling
{
    public class DumplingObjectPool : MonoBehaviour
    {
        public int maxNumberOfPooledDumplings;
        public int defaultNumberOfPooledDumplings;
        [SerializeField] private GameObject dumplingPrefab;

        private void Awake()
        {
            Assert.IsNotNull(dumplingPrefab);
            Assert.IsNotNull(dumplingPrefab.GetComponent<Dumpling_UsingObjectPool>());
        }
        
        private IObjectPool<Dumpling_UsingObjectPool> pool;
        public IObjectPool<Dumpling_UsingObjectPool> Pool
        {
            get
            {
                if (pool == null)
                {
                    pool = new ObjectPool<Dumpling_UsingObjectPool>(
                        OnCreatePooledDumpling, 
                        OnTakeDumplingFromPool,
                        OnReturnedDumplingToPool,
                        OnDestroyedPooledDumpling, true, defaultNumberOfPooledDumplings, maxNumberOfPooledDumplings);
                }
                return pool;
            }
        }
        private Dumpling_UsingObjectPool OnCreatePooledDumpling()
        {
            GameObject newDumplingGameObject = Instantiate(dumplingPrefab, this.transform, true);
            newDumplingGameObject.name = $"{dumplingPrefab.name}";
            Dumpling_UsingObjectPool newDumplingWithoutObjectPool = newDumplingGameObject.GetComponentInChildren<Dumpling_UsingObjectPool>();
            newDumplingWithoutObjectPool.DumplingPool = Pool;
            return newDumplingWithoutObjectPool;
        }
        private void OnTakeDumplingFromPool(Dumpling_UsingObjectPool _dumplingWithoutObjectPool)
        {
            _dumplingWithoutObjectPool.gameObject.SetActive(true);
        }
        private void OnReturnedDumplingToPool(Dumpling_UsingObjectPool _dumplingWithoutObjectPool)
        {
            _dumplingWithoutObjectPool.gameObject.SetActive(false);
        }
        private void OnDestroyedPooledDumpling(Dumpling_UsingObjectPool _dumplingWithoutObjectPool)
        {
            Destroy(_dumplingWithoutObjectPool.gameObject);
        }
    }
}
