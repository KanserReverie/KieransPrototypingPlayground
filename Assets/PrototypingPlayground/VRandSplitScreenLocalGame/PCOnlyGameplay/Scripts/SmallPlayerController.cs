using System;
using System.Collections;
using PrototypingPlayground.CustomInspector.ReadOnlyProperty;
using UnityEngine;
using UnityEngine.InputSystem;
namespace PrototypingPlayground.VRandSplitScreenLocalGame
{
    [RequireComponent(typeof(Rigidbody))]
    public class SmallPlayerController : MonoBehaviour
    {
        [Header("Player Variables")]
        [SerializeField] private float speed = 6.5f;
        [SerializeField] private float horizontalRotationSpeed = 80f;
        [SerializeField] private float verticalRotationSpeed = 80f;
        [SerializeField] private float jumpForce = 3f;
        [SerializeField] private float dashVelocity = 2f;
        [SerializeField] private float dashDistance = 2f;
        [Header("Read Only")]
        [SerializeField, ReadOnlyProperty] private Vector2 horizontalMovementInput;
        [SerializeField, ReadOnlyProperty] private float horizontalLookingInput;
        [SerializeField, ReadOnlyProperty] private float verticalLookingInput;
        [SerializeField, ReadOnlyProperty] private bool dashingForward;
        [SerializeField, ReadOnlyProperty] private float dashTimer;

        private Rigidbody smallPlayerRigidbody;
        private Transform cameraTransform;
        private Vector2 startingDashLocation;

        // Start is called before the first frame update
        void Start()
        {
            smallPlayerRigidbody = GetComponent<Rigidbody>();
            smallPlayerRigidbody.freezeRotation = true;
            cameraTransform = GetComponentInChildren<Camera>().transform;
        }

        private void Update()
        {
            if (transform.position.y < -10)
            {
                smallPlayerRigidbody.velocity = Vector3.zero;
                smallPlayerRigidbody.angularVelocity = Vector3.zero;
                transform.position = Vector3.zero;
            }
        }

        private void FixedUpdate()
        {
            if (dashingForward)
            {
                Dashing();
                return;
            }
            
            // Calculate the correct velocity by the axis of the input
            HorizontalMovement();
            
            Quaternion horizontalRotation = Quaternion.Euler(new Vector3(0, horizontalLookingInput, 0) * horizontalRotationSpeed * Time.fixedDeltaTime);
            smallPlayerRigidbody.MoveRotation(smallPlayerRigidbody.rotation * horizontalRotation);
            cameraTransform.Rotate(new Vector3(-verticalLookingInput, 0, 0) * verticalRotationSpeed * Time.fixedDeltaTime);
        }
        private void HorizontalMovement()
        {
            Vector3 desiredVelocity = new Vector3(horizontalMovementInput.x, 0, horizontalMovementInput.y) * (speed * Time.fixedDeltaTime);
            smallPlayerRigidbody.AddRelativeForce(desiredVelocity, ForceMode.Impulse);
        }
        
        private void Dashing()
        {
            if (dashTimer > 0)
            {
                Vector3 dashSpeed = new Vector3(0,0,dashVelocity + speed) * Time.fixedDeltaTime;
                smallPlayerRigidbody.AddRelativeForce(dashSpeed, ForceMode.Impulse);
                dashTimer -= Time.fixedDeltaTime;
                if (dashTimer < 0)
                {
                    FinishDash();
                }
            }
            else
            {
                FinishDash();
            }
        }

        public void FinishDash()
        {
            smallPlayerRigidbody.velocity = new Vector3(0, smallPlayerRigidbody.velocity.y, 0);
            smallPlayerRigidbody.angularVelocity = new Vector3(0, smallPlayerRigidbody.angularVelocity.y, 0);
            dashTimer = 0;
            dashingForward = false;
        }

        public void OnMove(InputAction.CallbackContext _movementInput)
        {
            horizontalMovementInput = _movementInput.ReadValue<Vector2>();
        }
        
        public void OnLook(InputAction.CallbackContext _lookInput)
        {
            Vector2 lookInput = _lookInput.ReadValue<Vector2>();
            horizontalLookingInput = lookInput.x;
            verticalLookingInput = lookInput.y;
        }
        
        public void OnJump(InputAction.CallbackContext _jumpInput)
        {
            if (_jumpInput.started)
            {
                smallPlayerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
        
        public void OnDash(InputAction.CallbackContext _dashInput)
        {
            if (_dashInput.performed)
            {
                if (dashTimer > 0)
                {
                    return;
                }
                smallPlayerRigidbody.velocity = new Vector3(0, smallPlayerRigidbody.velocity.y, 0);
                smallPlayerRigidbody.angularVelocity = new Vector3(0, smallPlayerRigidbody.angularVelocity.y, 0);
                startingDashLocation = new Vector2(transform.position.x, transform.position.z);
                dashingForward = true;
                SetDashTimer();
            }
        }
        
        private void SetDashTimer()
        {
            dashTimer = dashDistance / (dashVelocity + speed);
        }
    }
}
