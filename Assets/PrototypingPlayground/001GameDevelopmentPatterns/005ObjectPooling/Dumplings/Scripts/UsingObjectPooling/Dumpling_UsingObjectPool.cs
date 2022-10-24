using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pool;
namespace PrototypingPlayground._001GameDevelopmentPatterns._005ObjectPooling.Dumplings.UsingObjectPooling
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Dumpling_UsingObjectPool : MonoBehaviour
    {
        public IObjectPool<Dumpling_UsingObjectPool> DumplingPool { get; set; }
        
        private NavMeshAgent dumplingNavMeshAgent;
        private Vector3 finalDestination;
        public NavMeshAgent NavMeshAgent => dumplingNavMeshAgent;

        // Call this when you create the dumpling.
        public void Initialize(Vector3 _finalDestination, Vector3 _startingLocation, Quaternion _startingRotation)
        {
            dumplingNavMeshAgent = GetComponent<NavMeshAgent>();
            dumplingNavMeshAgent.Warp(_startingLocation);
            transform.rotation = _startingRotation; 
            SetDestination(_finalDestination);
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

        private void SetDestination(Vector3 _newDestination)
        {
            dumplingNavMeshAgent.destination = _newDestination;
            finalDestination = _newDestination;
        }
    }
}
