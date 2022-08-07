using System;
using UnityEngine;
using UnityEngine.AI;
namespace PrototypingPlayground.GameDevelopmentPatterns.ObjectPooling.Dumplings
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Dumpling : MonoBehaviour
    {
        private NavMeshAgent dumplingNavMeshAgent;
        public NavMeshAgent NavMeshAgent => dumplingNavMeshAgent;

        private void OnEnable()
        {
            dumplingNavMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Awake()
        {
            dumplingNavMeshAgent = GetComponent<NavMeshAgent>();
        }
    }
}
