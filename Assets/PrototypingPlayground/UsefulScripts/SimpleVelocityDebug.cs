using UnityEngine;
namespace PrototypingPlayground.UsefulScripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class SimpleVelocityDebug : MonoBehaviour
    {
        private Rigidbody ballRigidbody;

        private void Start()
        {
            ballRigidbody = GetComponent<Rigidbody>();
        }

        private void OnDrawGizmos()
        {
            if (!ballRigidbody)
            {
                ballRigidbody = GetComponent<Rigidbody>();
            }
            Gizmos.DrawLine(transform.position, transform.position + ballRigidbody.velocity);
        }
    }
}