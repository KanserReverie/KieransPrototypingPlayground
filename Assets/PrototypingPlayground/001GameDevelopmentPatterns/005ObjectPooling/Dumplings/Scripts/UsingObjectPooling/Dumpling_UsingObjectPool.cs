using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pool;
namespace PrototypingPlayground._001GameDevelopmentPatterns._005ObjectPooling.Dumplings.UsingObjectPooling
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class DumplingUsingObjectPool : MonoBehaviour
    {
        public IObjectPool<DumplingUsingObjectPool> DumplingPool { get; set; }
        
        private NavMeshAgent dumplingNavMeshAgent;
        private Vector3 finalDestination;
        public NavMeshAgent NavMeshAgent => dumplingNavMeshAgent;

        // Call this when you create the dumpling.
        public void Initialize(Vector3 finalDestination, Vector3 startingLocation, Quaternion startingRotation)
        {
            dumplingNavMeshAgent = GetComponent<NavMeshAgent>();
            dumplingNavMeshAgent.Warp(startingLocation);
            transform.rotation = startingRotation; 
            SetDestination(finalDestination);
        }

        private void FixedUpdate()
        {
            if (Vector3.Distance(finalDestination, transform.position) < 1f)
            {
                TurnOffDumpling();
            }
        }
        private void TurnOffDumpling()
        {
            ResetDumpling();
            DumplingPool.Release(this);
        }
        
        private void ResetDumpling()
        {
            dumplingNavMeshAgent.ResetPath();
            dumplingNavMeshAgent.destination = gameObject.transform.position;
        }

        private void SetDestination(Vector3 newDestination)
        {
            dumplingNavMeshAgent.destination = newDestination;
            finalDestination = newDestination;
        }
    }
}
