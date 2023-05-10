using UnityEngine;
using UnityEngine.AI;
namespace PrototypingPlayground._001GameDevelopmentPatterns._005ObjectPooling.Dumplings.WithoutObjectPooling
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class DumplingWithoutObjectPool : MonoBehaviour
    {
        private NavMeshAgent dumplingNavMeshAgent;
        private Vector3 finalDestination;
        public NavMeshAgent NavMeshAgent => dumplingNavMeshAgent;

        private void Awake()
        {
            dumplingNavMeshAgent = GetComponent<NavMeshAgent>();
        }
        
        // Call this when you create the dumpling.
        public void Initialize(Vector3 finalDestination, Vector3 startingLocation, Quaternion startingRotation)
        {
            SetDestination(finalDestination);
            dumplingNavMeshAgent.Warp(startingLocation);
            transform.rotation = startingRotation; 
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
        
        private void SetDestination(Vector3 newDestination)
        {
            dumplingNavMeshAgent.destination = newDestination;
            finalDestination = newDestination;
        }
    }
}
