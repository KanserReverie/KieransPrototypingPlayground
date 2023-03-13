using System;
using Unity.VisualScripting;
using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._005ObjectPooling.GenericObjectPoolPattern.ExampleImplementation2
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 5.0f;
        [SerializeField] private float rotationSpeed = 520f;

        private void Update()
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal"); // -1 is left
            float  verticalInput = Input.GetAxisRaw("Vertical"); // -1 is down
            
            Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);
            moveDirection.Normalize();
            transform.Translate(moveDirection * movementSpeed * Time.deltaTime, Space.World);

            if (moveDirection != Vector3.zero)
            {
                // This is the direction we want to look at.
                Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
                // This will get our current rotation and move it towards where we want to look at by our rotation speed.
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}