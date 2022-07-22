using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PrototypingPlayground.ThrowingDumpling
{
    public class DumplingController : MonoBehaviour
    {
        private Rigidbody dumplingRigidBody;
        private Vector2 horizontalMoveInput;
        [SerializeField] private float horizontalMovementSpeed = 5f;
        
        // Start is called before the first frame update
        void Start()
        {
            dumplingRigidBody = GetComponent<Rigidbody>();
            dumplingRigidBody.freezeRotation = true;
        }

        private void FixedUpdate()
        {
            dumplingRigidBody.AddForce(new Vector3(horizontalMoveInput.x, 0, horizontalMoveInput.y) * horizontalMovementSpeed);
        }

        public void OnMove(InputAction.CallbackContext _moveInput)
        {
            horizontalMoveInput = _moveInput.ReadValue<Vector2>().normalized;
        }
    }
}
