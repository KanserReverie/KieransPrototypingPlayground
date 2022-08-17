using UnityEngine;
namespace Samples.AI_Navigation._1._0._0_exp._4.Build_And_Connect_NavMesh_Surfaces.Scripts
{
    /// <summary>
    /// Destroy owning GameObject if any collider with a specific tag is trespassing
    /// </summary>
    public class DestroyOnTrigger : MonoBehaviour
    {
        public string m_Tag = "Player";

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == m_Tag)
                Destroy(gameObject);
        }
    }
}