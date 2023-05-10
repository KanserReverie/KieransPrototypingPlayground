using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._005ObjectPooling.GenericObjectPoolPattern.ExampleImplementation2
{
    public class Bullet : GenericPoolableObject
    {
        [SerializeField] private float secondsUntilDestroyed = 2;
        private float currentSecondsUntilDestroyed;
        public Rigidbody Rigidbody { get; private set; }

        /// <summary>
        /// Unity's method called on object enable
        /// </summary>
        public override void PrepareToUse()
        {
            base.PrepareToUse();
            currentSecondsUntilDestroyed = secondsUntilDestroyed;

            if (Rigidbody == null)
            {
                Rigidbody = GetComponentInChildren<Rigidbody>();

                if (Rigidbody == null)
                {
                    Rigidbody = gameObject.AddComponent<Rigidbody>();
                }
            }
        }
        
        
        /// <summary>
        /// Unity's method called every frame
        /// </summary>
        private void Update()
        {
            currentSecondsUntilDestroyed -= Time.deltaTime;
            // Waiting for timeout
            if (currentSecondsUntilDestroyed  <= 0)
            {
                // Returning object
                ReturnToPool();
            }
        }
    }
}