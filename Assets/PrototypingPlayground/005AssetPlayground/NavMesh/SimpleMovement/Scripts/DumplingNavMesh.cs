using UnityEngine;
using UnityEngine.AI;
namespace PrototypingPlayground._005AssetPlayground.NavMesh.SimpleMovement
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
