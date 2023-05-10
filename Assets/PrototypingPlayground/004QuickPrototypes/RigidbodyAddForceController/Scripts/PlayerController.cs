using UnityEngine;
using UnityEngine.InputSystem;
namespace PrototypingPlayground._004QuickPrototypes.RigidbodyAddForceController
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float jumpForce = 10;
        private Rigidbody playerRigidbody;
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

        public void OnJump(InputAction.CallbackContext jumpInput)
        {
            if (jumpInput.performed)
            {
                this.jumpInput = true;
            }
        }
    }
}
