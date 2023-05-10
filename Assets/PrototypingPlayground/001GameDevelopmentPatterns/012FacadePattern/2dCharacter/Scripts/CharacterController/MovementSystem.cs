using UnityEngine;
// ReSharper disable All

namespace PrototypingPlayground._001GameDevelopmentPatterns._012FacadePattern._2dCharacter.CharacterController
{
    public class MovementSystem : MonoBehaviour
    {
        private Rigidbody playerRigidbody;
        private float walkInput;
        private float walkSpeed;
        private bool movementEnabled;

        public void DisablePlayerMovement()
        {
            movementEnabled = false;
            if (playerRigidbody == null)
            {
                SetupPlayerRigidbody();
            }
            playerRigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }
        
        public void EnablePlayerMovement()
        {
            movementEnabled = true;
            if (playerRigidbody == null)
            {
                SetupPlayerRigidbody();
            }
            playerRigidbody.constraints = RigidbodyConstraints.None;
            
            playerRigidbody.constraints = 
                RigidbodyConstraints.FreezePositionZ | 
                RigidbodyConstraints.FreezeRotationX | 
                RigidbodyConstraints.FreezeRotationY | 
                RigidbodyConstraints.FreezeRotationZ;
        }

        private void Awake()
        {
            SetupPlayerRigidbody();
            movementEnabled = false;
        }
        
        private void SetupPlayerRigidbody()
        {
            playerRigidbody = GetComponentInChildren<Rigidbody>();
            
            if (playerRigidbody == null)
            {
                playerRigidbody = gameObject.AddComponent<Rigidbody>();
            }

            playerRigidbody.constraints = RigidbodyConstraints.None;
            
            playerRigidbody.constraints = 
                RigidbodyConstraints.FreezePositionZ | 
                RigidbodyConstraints.FreezeRotationX | 
                RigidbodyConstraints.FreezeRotationY | 
                RigidbodyConstraints.FreezeRotationZ;

            playerRigidbody.interpolation = RigidbodyInterpolation.Extrapolate;
            playerRigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        }

        private void FixedUpdate()
        {
            if (!movementEnabled) return;
            if (walkInput != 0)
            {
                playerRigidbody.velocity = new Vector3(walkInput * walkSpeed, playerRigidbody.velocity.y, 0);
            }
        }

        public void MovePlayerToSpawn(Vector3 _spawnLocation)
        {
            playerRigidbody.MovePosition(_spawnLocation);
            transform.position = _spawnLocation;
        }
        
        public void Walk(float _walkInput, float _walkSpeed)
        {
            if (!movementEnabled) return;
            walkInput = _walkInput;
            walkSpeed = _walkSpeed;
        }
        public void Jump(float _jumpForce)
        {
            if (!movementEnabled) return;
            playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, _jumpForce, 0);
        }
    }
}
