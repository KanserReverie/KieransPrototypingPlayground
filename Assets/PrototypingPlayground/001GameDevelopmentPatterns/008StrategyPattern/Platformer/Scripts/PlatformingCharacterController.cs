using System;
using PrototypingPlayground._001GameDevelopmentPatterns._008StrategyPattern.Platformer.Obstacles;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;

namespace PrototypingPlayground._001GameDevelopmentPatterns._008StrategyPattern.Platformer
{
    public class PlatformingCharacterController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 4.0f;
        [SerializeField] private float jumpForce = 10.0f;
        [SerializeField] private float groundCheckDistance = 0.2f;
        
        private float horizontalMoveInput;
        private bool playerJumpInput;
        private Vector2 playerAbilityInput;
        private Rigidbody playerRigidbody;
        private CapsuleCollider playerCapsuleCollider;
    
        private void Start()
        {
            playerRigidbody = GetComponent<Rigidbody>();
            playerCapsuleCollider = GetComponentInChildren<CapsuleCollider>();
            
            Assert.IsNotNull(playerRigidbody);
            Assert.IsNotNull(playerCapsuleCollider);
        }

        private Vector3 BottomPointPlayerCapsuleCollider()
        {
            if (!playerCapsuleCollider)
            {
                playerCapsuleCollider = GetComponentInChildren<CapsuleCollider>();
            }
            Vector3 capsuleBottomPivot = transform.position;
            capsuleBottomPivot += playerCapsuleCollider.center;
            float playerCylinderHeight = playerCapsuleCollider.height;
            playerCylinderHeight -= playerCapsuleCollider.radius * 2;
            if (playerCylinderHeight < 0) playerCylinderHeight = 0;
            capsuleBottomPivot.y -= playerCylinderHeight/2;
            return capsuleBottomPivot;
        }

        private void FixedUpdate()
        {
            Vector3 playerRigidbodyVelocity = playerRigidbody.velocity;
            playerRigidbodyVelocity = new Vector3(horizontalMoveInput*moveSpeed, playerRigidbodyVelocity.y, playerRigidbodyVelocity.z);
            
            if (playerJumpInput)
            {
                if (IsThereGroundBellowUs())
                {
                    playerRigidbodyVelocity.y = jumpForce;
                }
                playerJumpInput = false;
            }
            
            if ((playerAbilityInput.x is < -0.1f or > 0.1f) || (playerAbilityInput.y is < -0.1f or > 0.1f))
            {
                if (Mathf.Abs(playerAbilityInput.x) > Mathf.Abs(playerAbilityInput.y))
                {
                    Debug.Log($"Use horizontal ability || {playerAbilityInput.x}");
                }
                else
                {
                    Debug.Log($"Use vertical ability || {playerAbilityInput.y}");
                }
                playerAbilityInput = Vector2.zero;
            }
            
            playerRigidbody.velocity = playerRigidbodyVelocity;
        }
        private bool IsThereGroundBellowUs()
        {
            RaycastHit [] hitInfo;
            hitInfo = Physics.SphereCastAll(BottomPointPlayerCapsuleCollider(), playerCapsuleCollider.radius, Vector3.down, groundCheckDistance);

            foreach (RaycastHit raycastHit in hitInfo)
            {
                Obstacle obstacle = raycastHit.collider.gameObject.GetComponentInChildren<Obstacle>();
                PlatformingCharacterController player = raycastHit.collider.gameObject.GetComponentInChildren<PlatformingCharacterController>();
                if (obstacle == null && player == null)
                {
                    return true;
                }
            }
            return false;
        }

        public void OnMove(InputAction.CallbackContext _moveInput)
        {
            horizontalMoveInput = _moveInput.ReadValue<Vector2>().x;
        }
        
        public void OnJump(InputAction.CallbackContext _jumpInput)
        {
            if (_jumpInput.performed)
            {
                playerJumpInput = true;
            }
        }
        
        public void OnAbility(InputAction.CallbackContext _abilityInput)
        {
            if (_abilityInput.performed)
            {
                playerAbilityInput = _abilityInput.ReadValue<Vector2>();
            }
        }
    }
}
