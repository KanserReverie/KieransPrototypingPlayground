using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PrototypingPlayground._1.GameDevelopmentPatterns._7.VisitorPattern.BasicPlatformer.Scripts
{
    public class BasicPlatformerRigidbodyCharacterController : MonoBehaviour
    {
        [Header("Rigidbody")]
        [SerializeField] private bool freezeRotation;
        [SerializeField] private bool freezeZAxis;
        private Vector3 movementInput = Vector3.zero;
        private new Rigidbody rigidbody;
        
        private void Start()
        {
            SetUpRigidBody();
        }

        private void SetUpRigidBody()
        {
            rigidbody = gameObject.AddComponent<Rigidbody>();
            if (freezeRotation)
            {
                rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            }
            if (freezeZAxis)
            {
                rigidbody.constraints = rigidbody.constraints | RigidbodyConstraints.FreezePositionZ;
            }
        }

        public void Jump(InputAction.CallbackContext _jumpInput)
        {
            if (_jumpInput.performed)
            {
                Debug.Log("Jump Performed");
            }
        }

        public void Move(InputAction.CallbackContext _moveInput)
        {
            movementInput.x = _moveInput.ReadValue<float>();
            Debug.Log($"Move Input = {movementInput}");
         }

        public void UseAbility(InputAction.CallbackContext _useAbilityInput)
        {
            if (_useAbilityInput.performed)
            {
                Debug.Log("Use Ability");
            }
        }
    }
}
