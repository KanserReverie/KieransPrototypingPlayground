using UnityEngine;
using Random = UnityEngine.Random;
namespace PrototypingPlayground._2.BasicConcepts.UnityEvents.Scripts
{
    public class BouncingSpheresManager : MonoBehaviour
    {
        [SerializeField] private float radius = 5.0f;
        [SerializeField] private float power = 10.0f;
        [SerializeField] private float upwardsModifier = 3f;
        [SerializeField] private float gravityMultiplier = 2f;
        
        private Rigidbody[] _spheresRigidbodies;
        
        private void Start()
        {
            _spheresRigidbodies = GetComponentsInChildren<Rigidbody>();
        }

        public void FixedUpdate()
        {
            for (int i = 0; i < _spheresRigidbodies.Length; i++)
            {
                _spheresRigidbodies[i].AddForce(Physics.gravity * gravityMultiplier);
            }
        }

        public void AddExplosiveForceToSpheres()
        {
            for (int i = 0; i < _spheresRigidbodies.Length; i++)
            {
                float powerForce = Random.Range(power, power * 2f);
                Vector3 position = transform.position;
                Vector3 explosiveLocation = new Vector3(
                    Random.Range(0f, position.x),
                    Random.Range(0f, position.y),
                    Random.Range(0f, position.z));
                _spheresRigidbodies[i].AddExplosionForce(powerForce, explosiveLocation, radius, upwardsModifier);
            }
        }
    }
}
