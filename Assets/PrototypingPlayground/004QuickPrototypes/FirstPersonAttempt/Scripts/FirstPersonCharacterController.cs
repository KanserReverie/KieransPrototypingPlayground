using System;
using PrototypingPlayground.CustomInspector.SerializableProperties;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;

namespace PrototypingPlayground._004QuickPrototypes.FirstPersonAttempt.Scripts
{
    public class FirstPersonCharacterController : MonoBehaviour
    {
        [SerializeField, ReadOnlyField] private CharacterController characterController;
        [SerializeField] private float walkingSpeed = 4;
        [SerializeField] private float gravityAcceleration = 9.81f;

        [SerializeField] private Vector3 movementSpeed;
        private Vector2 movementInput;

        public void Awake()
        {
            characterController = GetComponentInChildren<CharacterController>();
            Assert.IsNotNull(characterController);
        }
        public void Start()
        {
            movementSpeed = Vector3.zero;
        }

        public void FixedUpdate()
        {
            
            Vector3 movementThisFrame = new Vector3(0,0,0);
            movementThisFrame.x = HorizontalMovementSideToSide();
            movementThisFrame.z = HorizontalMovementForwardAndBack();
            movementThisFrame.y = FixedUpdateVerticalMovementGravity();

            movementSpeed = movementThisFrame;
            FixedUpdateMoveCharacter(movementSpeed);
        }
        
        private void FixedUpdateMoveCharacter(Vector3 _movementSpeed)
        {
            Vector3 characterMovementThisFixedUpdate;
            characterMovementThisFixedUpdate = movementSpeed; 
            characterMovementThisFixedUpdate *= Time.fixedDeltaTime;
            characterController.Move(characterMovementThisFixedUpdate);
        }

        private float FixedUpdateVerticalMovementGravity()
        {
            float gravityForce;
            gravityForce = -gravityAcceleration;
            
            if (!characterController.isGrounded)
            {
                gravityForce = movementSpeed.y;
                gravityForce -= (gravityAcceleration * Time.fixedDeltaTime);
            }
            
            return gravityForce;
        }
        private float HorizontalMovementSideToSide()
        {
            float sideToSideMovement;
            sideToSideMovement = movementInput.x;
            sideToSideMovement *= walkingSpeed;
            return sideToSideMovement;
        }
        
        private float HorizontalMovementForwardAndBack()
        {
            float forwardAndBackMovement;
            forwardAndBackMovement = movementInput.y;
            forwardAndBackMovement *= walkingSpeed;
            return forwardAndBackMovement;
        }

        public void OnMove(InputAction.CallbackContext _moveInput)
        {
            movementInput = _moveInput.ReadValue<Vector2>();
            movementInput.Normalize();
        }

    }
}
