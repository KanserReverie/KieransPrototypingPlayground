using System;
using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._005ObjectPooling.GenericObjectPoolPattern.ExampleImplementation2
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerShooting : MonoBehaviour
    {
        [SerializeField] private float timeBetweenShots = 0.3f;
        private float timeSinceLastShot;
        // Reference to used object pool
        [SerializeField] private BulletObjectPool objectPool;
        public void Update()
        {
            timeSinceLastShot += Time.deltaTime;
            if (Input.GetKey(KeyCode.Space))
            {
                if (timeSinceLastShot >= timeBetweenShots)
                {
                    Shoot();
                }
            }
        }

        private void Shoot()
        {
                // Setup prefab instance to shoot!
                Bullet bullet = objectPool.GetPrefabInstance();
                bullet.transform.position = transform.position + Vector3.forward * 0.5f;
                bullet.transform.up = transform.up;
                bullet.Rigidbody.AddForce(transform.forward * 10, ForceMode.Impulse);
                timeSinceLastShot = 0;
                Debug.Log("Shoot");
        }
    }
}