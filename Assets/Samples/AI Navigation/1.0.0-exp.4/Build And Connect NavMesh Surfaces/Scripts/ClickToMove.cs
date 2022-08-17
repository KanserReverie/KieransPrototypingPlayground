using UnityEngine;
using UnityEngine.AI;
namespace Samples.AI_Navigation._1._0._0_exp._4.Build_And_Connect_NavMesh_Surfaces.Scripts
{
    /// <summary>
    /// Use physics raycast hit from mouse click to set agent destination 
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
    public class ClickToMove : MonoBehaviour
    {
        NavMeshAgent m_Agent;
        RaycastHit m_HitInfo = new RaycastHit();
    
        void Start()
        {
            m_Agent = GetComponent<NavMeshAgent>();
        }
    
        void Update()
        {
            if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftShift))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray.origin, ray.direction, out m_HitInfo))
                    m_Agent.destination = m_HitInfo.point;
            }
        }
    }
}