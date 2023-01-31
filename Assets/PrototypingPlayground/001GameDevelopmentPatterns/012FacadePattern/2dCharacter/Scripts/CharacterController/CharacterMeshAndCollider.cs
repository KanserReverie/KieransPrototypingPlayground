using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._012FacadePattern._2dCharacter.CharacterController
{
    public class CharacterMeshAndCollider : MonoBehaviour
    {
        private MeshRenderer playerMeshRenderer;
        private Collider playerColliders;
        
        private void Awake()
        {
            GetThePlayerMeshAndCollider();
        }
        
        private void GetThePlayerMeshAndCollider()
        {
            playerMeshRenderer = GetComponentInChildren<MeshRenderer>();
            playerColliders = GetComponentInChildren<Collider>();
        }

        public void TurnOffMeshesAndColliders()
        {
            playerMeshRenderer.gameObject.SetActive(false);
            playerColliders.gameObject.SetActive(false);
        }
        
        public void TurnOnMeshesAndColliders()
        {
            playerMeshRenderer.gameObject.SetActive(true);
            playerColliders.gameObject.SetActive(true);
        }
    }
}
