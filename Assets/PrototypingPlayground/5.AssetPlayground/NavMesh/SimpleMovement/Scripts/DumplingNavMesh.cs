using UnityEngine;
using UnityEngine.AI;
namespace PrototypingPlayground._5.AssetPlayground.NavMesh.SimpleMovement.Scripts
{
    public class DumplingNavMesh : MonoBehaviour
    {
        [SerializeField] private Transform movePositionTransform;
        private NavMeshAgent navMeshAgent;

        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }
        void Update()
        {
            navMeshAgent.destination = movePositionTransform.position;
        }
    }
}
