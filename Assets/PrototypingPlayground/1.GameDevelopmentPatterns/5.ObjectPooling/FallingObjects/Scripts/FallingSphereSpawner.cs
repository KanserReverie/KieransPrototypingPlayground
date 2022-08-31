using System.Collections;
using UnityEngine;
namespace PrototypingPlayground._1.GameDevelopmentPatterns._5.ObjectPooling.FallingObjects
{
    public class FallingSphereSpawner : MonoBehaviour
    {
        [SerializeField] private ObjectPoolFallingSphere objectPoolFallingSphere;
        [SerializeField] private float spawningTimer = 2.0f;
        public bool spawning;

        private void OnValidate()
        {
            objectPoolFallingSphere = FindObjectOfType<ObjectPoolFallingSphere>();
        }
        private void Awake()
        {
            spawning = true;
            StartCoroutine(StartSpawningSpheres());
        }
        private IEnumerator StartSpawningSpheres()
        {
            while (spawning)
            {
                SpawnSphere();
                yield return new WaitForSeconds(spawningTimer);
            }
        }
        private void SpawnSphere()
        {
            var fallingSphere = objectPoolFallingSphere.Pool.Get();
            fallingSphere.transform.position = this.transform.position;
            fallingSphere.transform.rotation = this.transform.rotation;
            fallingSphere.transform.parent = this.transform;
        }
    }
}
