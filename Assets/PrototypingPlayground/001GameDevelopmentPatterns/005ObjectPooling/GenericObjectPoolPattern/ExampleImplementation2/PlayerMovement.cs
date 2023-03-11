using System;
using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._005ObjectPooling.GenericObjectPoolPattern.ExampleImplementation2
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody playerRigidbody;
        private float horizontalInput;
        private float verticalInput;
        [SerializeField] private float movementSpeed = 20.0f;

        private void Start()
        {
            playerRigidbody = GetComponent<Rigidbody>();
            playerRigidbody.useGravity = false;
        }

        private void Update()
        {
            horizontalInput = Input.GetAxisRaw("Horizontal"); // -1 is left
            verticalInput = Input.GetAxisRaw("Vertical"); // -1 is down
            Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);
            moveDirection.Normalize();
            transform.Translate(moveDirection * movementSpeed * Time.deltaTime);
        }

        private void FixedUpdate()
        {
        }
    }
}