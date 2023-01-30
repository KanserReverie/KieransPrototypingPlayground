using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._012FacadePattern._2dCharacter.CharacterController
{
    public class MovementSystem : MonoBehaviour
    {
        private Rigidbody playerRigidbody;
        
        private void Awake()
        {
            GetThePlayerRigidbody();
        }
        
        private void GetThePlayerRigidbody()
        {
            playerRigidbody = GetComponentInChildren<Rigidbody>();
            
            if (playerRigidbody == null)
            {
                playerRigidbody = gameObject.AddComponent<Rigidbody>();
            }
        }
    }
}
