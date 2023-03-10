using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._005ObjectPooling.GenericObjectPoolPattern.ExampleImplementation
{
    /// <summary>
    /// Timeout object.
    /// It return itself to object pool after provided timeout.
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public class TimeoutObject : GenericPoolableObject
    {
        // Time after which object will be destroyed
        [SerializeField]
        private float timeout = 2;
        // Saving enable time to calculate when to destroy itself
        private float startTime;
        // Reference to rigidbody used in spawner
        public Rigidbody2D Rigidbody { get; private set; }
        /// <summary>
        /// Unity's method called on object enable
        /// </summary>
        public override void PrepareToUse()
        {
            base.PrepareToUse();
            startTime = Time.time;
            if (!Rigidbody)
            {
                Rigidbody = GetComponent<Rigidbody2D>();
            }
        }
        /// <summary>
        /// Unity's method called every frame
        /// </summary>
        private void Update()
        {
            // Waiting for timeout
            if (Time.time - startTime > timeout)
            {
                // Returning object
                ReturnToPool();
            }
        }
    }
}