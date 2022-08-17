using UnityEngine;
namespace Samples.AI_Navigation._1._0._0_exp._4.Build_And_Connect_NavMesh_Surfaces.Scripts
{
    /// <summary>
    /// Prefab spawner with a key input
    /// </summary>
    public class SpawnPrefabOnKeyDown : MonoBehaviour
    {
        public GameObject m_Prefab;
        public KeyCode m_KeyCode;
    
        void Update()
        {
            if (Input.GetKeyDown(m_KeyCode) && m_Prefab != null)
                Instantiate(m_Prefab, transform.position, transform.rotation);
        }
    }
}