using UnityEngine;
using UnityEngine.InputSystem;
namespace PrototypingPlayground._004QuickPrototypes.RigidbodyAddForceController
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float jumpForce = 10;
        private Rigidbody playerRigidbody;
        private Vector2 horizontalMovementInput;
        private bool jumpInput;
        
        void Start()
        {
            playerRigidbody = GetComponentInChildren<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            if (jumpInput) Jump();

        }
        private void Jump()
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce);
            jumpInput = false;
        }

        public void OnHorizontalMovement(InputAction.CallbackContext _horizontalInput)
        {
            horizontalMovementInput = _horizontalInput.ReadValue<Vector2>().normalized;
        }
        public void OnJump(InputAction.CallbackContext _jumpInput)
        {
            if (_jumpInput.performed)
            {
                jumpInput = true;
            }
        }
    }
}
