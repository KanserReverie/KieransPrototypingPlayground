using System;
using UnityEngine;
using UnityEngine.InputSystem;
namespace PrototypingPlayground._004QuickPrototypes._20Minute2dPlatformerController.Attempt1.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Vector2 moveInput;
        [SerializeField] private bool jumpInput;
        [SerializeField] private float speed = 4f;
        [SerializeField] private float jump = 4f;
        private Rigidbody playerRigidbody;

        private void Awake()
        {
            playerRigidbody = GetComponentInChildren<Rigidbody>();
        }

        private void FixedUpdate()
        {
            playerRigidbody.velocity = new Vector3(moveInput.x * speed, playerRigidbody.velocity.y, 0);
            if (jumpInput == true)
            {
                playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, jump, 0);
                jumpInput = false;
            }
        }
        public void onMove(InputAction.CallbackContext _input)
        {
            if (_input.performed)
            {
                moveInput = _input.ReadValue<Vector2>();
            }
        }
        public void oJump(InputAction.CallbackContext _input)
        {
            if (_input.performed)
            {
                jumpInput = true;
            }
        }
    }
}