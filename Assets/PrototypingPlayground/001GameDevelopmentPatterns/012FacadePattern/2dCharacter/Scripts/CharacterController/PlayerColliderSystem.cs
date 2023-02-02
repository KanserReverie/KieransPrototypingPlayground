using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._012FacadePattern._2dCharacter.CharacterController
{
    public class PlayerColliderSystem : MonoBehaviour
    {
        public void TurnOffPlayerColliders()
        {
            Collider [] playerColliders = GetComponentsInChildren<Collider>();
            if (playerColliders != null)
            {
                foreach (Collider collider in playerColliders)
                {
                    if (collider != null)
                    {
                        collider.enabled = false;
                    }
                }
            }
        }
        
        public void TurnOnPlayerColliders()
        {
            Collider [] playerColliders = GetComponentsInChildren<Collider>();
            if (playerColliders != null)
            {
                foreach (Collider collider in playerColliders)
                {
                    if (collider != null)
                    {
                        collider.enabled = true;
                    }
                }
            }
        }
    }
}
