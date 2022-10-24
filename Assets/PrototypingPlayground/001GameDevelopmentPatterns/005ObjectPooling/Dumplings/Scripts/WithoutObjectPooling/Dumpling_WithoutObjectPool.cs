using UnityEngine;
using UnityEngine.AI;
namespace PrototypingPlayground._001GameDevelopmentPatterns._005ObjectPooling.Dumplings.WithoutObjectPooling
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Dumpling_WithoutObjectPool : MonoBehaviour
    {
        private NavMeshAgent dumplingNavMeshAgent;
        private Vector3 finalDestination;
        public NavMeshAgent NavMeshAgent => dumplingNavMeshAgent;

        private void Awake()
        {
            dumplingNavMeshAgent = GetComponent<NavMeshAgent>();
        }
        
        // Call this when you create the dumpling.
        public void Initialize(Vector3 _finalDestination, Vector3 _startingLocation, Quaternion _startingRotation)
        {
            SetDestination(_finalDestination);
            dumplingNavMeshAgent.Warp(_startingLocation);
            transform.rotation = _startingRotation; 
        }

        private void FixedUpdate()
        {
            if (Vector3.Distance(finalDestination, transform.position) < 0.2f)
            {
                TurnOffDumpling();
            }
        }
        private void TurnOffDumpling()
        {
            Destroy(this.gameObject);
        }
        
        private void SetDestination(Vector3 _newDestination)
        {
            dumplingNavMeshAgent.destination = _newDestination;
            finalDestination = _newDestination;
        }
    }
}
