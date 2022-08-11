using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Pool;
namespace PrototypingPlayground.GameDevelopmentPatterns.ObjectPooling.FallingObjects
{
    public class FallingSphere : MonoBehaviour
    {
        public IObjectPool<FallingSphere> Pool { get; set; }
        
        private void Update()
        {
            if (transform.position.y < - 20.0f)
            {
                ResetRigidbody();
                Pool.Release(this);
            }
        }
        public void ResetRigidbody()
        {
            Rigidbody thisRigidbody = GetComponentInChildren<Rigidbody>();
            if (thisRigidbody != null)
            {
                thisRigidbody.velocity = Vector3.zero; 
                thisRigidbody.angularVelocity = Vector3.zero;
            }
        }
    }
}
