using UnityEngine;
using Random = UnityEngine.Random;
namespace PrototypingPlayground._002BasicConcepts.UnityEvents
{
    public class BouncingSpheresManager : MonoBehaviour
    {
        [SerializeField] private float radius = 5.0f;
        [SerializeField] private float power = 10.0f;
        [SerializeField] private float upwardsModifier = 3f;
        [SerializeField] private float gravityMultiplier = 2f;
        
        private Rigidbody[] spheresRigidbodies;
        
        private void Start()
        {
            spheresRigidbodies = GetComponentsInChildren<Rigidbody>();
        }

        public void FixedUpdate()
        {
            for (int i = 0; i < spheresRigidbodies.Length; i++)
            {
                spheresRigidbodies[i].AddForce(Physics.gravity * gravityMultiplier);
            }
        }

        public void AddExplosiveForceToSpheres()
        {
            for (int i = 0; i < spheresRigidbodies.Length; i++)
            {
                float powerForce = Random.Range(power, power * 2f);
                Vector3 position = transform.position;
                Vector3 explosiveLocation = new Vector3(
                    Random.Range(0f, position.x),
                    Random.Range(0f, position.y),
                    Random.Range(0f, position.z));
                spheresRigidbodies[i].AddExplosionForce(powerForce, explosiveLocation, radius, upwardsModifier);
            }
        }
    }
}
