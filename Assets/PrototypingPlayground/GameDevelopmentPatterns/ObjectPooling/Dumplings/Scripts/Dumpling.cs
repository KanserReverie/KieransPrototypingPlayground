using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pool;
namespace PrototypingPlayground.GameDevelopmentPatterns.ObjectPooling.Dumplings
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Dumpling : MonoBehaviour
    {
        public IObjectPool<Dumpling> DumplingPool { get; set; }
        
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

        public void OnDisable()
        {
            ResetDumpling();
        }

        private void FixedUpdate()
        {
            if (Vector3.Distance(finalDestination, transform.position) < 1.0f)
            {
                TurnOffDumpling();
            }
        }
        private void TurnOffDumpling()
        {
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
