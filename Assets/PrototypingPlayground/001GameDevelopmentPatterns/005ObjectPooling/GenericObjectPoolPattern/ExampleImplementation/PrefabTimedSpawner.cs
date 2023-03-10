using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._005ObjectPooling.GenericObjectPoolPattern.ExampleImplementation
{
    /// <summary>
    /// Prefab spawner.
    /// Component uses object pool to get prefab instance every few moments.
    /// </summary>
    public class PrefabTimedSpawner : MonoBehaviour
    {
        // Spawn rate
        [SerializeField] private float spawnRatePerMinute = 30;
        
        // Current spawn count
        private int currentCount = 0;

        // Reference to used object pool
        [SerializeField] private TimedObjectObjectPool objectPool;
        
        private void Update()
        {
            var targetCount = Time.time * (spawnRatePerMinute / 60);
            while (targetCount > currentCount)
            {
                // Setup prefab instance to shoot!
                var inst = objectPool.GetPrefabInstance();
                inst.transform.position = transform.position;
                inst.transform.up = -transform.up;
                inst.Rigidbody.AddForce(inst.transform.rotation * (Vector2.up * 10), ForceMode2D.Impulse);
                currentCount++;
            }
        }
    }
}