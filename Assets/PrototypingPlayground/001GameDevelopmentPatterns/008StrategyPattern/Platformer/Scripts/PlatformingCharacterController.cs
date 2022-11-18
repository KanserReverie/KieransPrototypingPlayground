using UnityEngine;
using UnityEngine.InputSystem;

namespace PrototypingPlayground._001GameDevelopmentPatterns._008StrategyPattern.Platformer.Scripts
{
    public class PlatformingCharacterController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 4.0f;
        [SerializeField] private float jumpForce = 10.0f;
        
        private float horizontalMoveInput;
        private bool playerJumpInput;
        private Vector2 playerAbilityInput;
        private Rigidbody playerRigidbody;
    
        private void Start()
        {
            playerRigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            Vector3 playerRigidbodyVelocity = playerRigidbody.velocity;
            playerRigidbodyVelocity = new Vector3(horizontalMoveInput*moveSpeed, playerRigidbodyVelocity.y, playerRigidbodyVelocity.z);
            
            if (playerJumpInput)
            {
                playerRigidbodyVelocity.y = jumpForce;
                playerJumpInput = false;
            }
            
            if ((playerAbilityInput.x is < -0.1f or > 0.1f)
                || (playerAbilityInput.y is < -0.1f or > 0.1f))
            {
                if (Mathf.Abs(playerAbilityInput.x) > Mathf.Abs(playerAbilityInput.y))
                {
                    Debug.Log($"Use horizontal SpawnShield ability || {playerAbilityInput.x}");
                }
                else
                {
                    Debug.Log($"Use vertical SpawnShield ability || {playerAbilityInput.y}");
                }
                playerAbilityInput = Vector2.zero;
            }
            
            playerRigidbody.velocity = playerRigidbodyVelocity;
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
