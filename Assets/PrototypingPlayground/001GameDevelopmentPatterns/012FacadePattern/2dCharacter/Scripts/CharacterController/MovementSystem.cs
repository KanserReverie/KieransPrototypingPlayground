using System;
using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._012FacadePattern._2dCharacter.CharacterController
{
    public class MovementSystem : MonoBehaviour
    {
        private Rigidbody playerRigidbody;
        private bool movementEnabled = false;
        
        private void Awake()
        {
            GetThePlayerRigidbody();
            movementEnabled = false;
        }
        
        private void GetThePlayerRigidbody()
        {
            playerRigidbody = GetComponentInChildren<Rigidbody>();
            
            if (playerRigidbody == null)
            {
                playerRigidbody = gameObject.AddComponent<Rigidbody>();
            }
        }


        public void Update()
        {
            // Move Player Here
        }
        
        public void MovePlayerToSpawn(Vector3 _spawnLocation)
        {
            playerRigidbody.MovePosition(_spawnLocation);
        }
    }
}
