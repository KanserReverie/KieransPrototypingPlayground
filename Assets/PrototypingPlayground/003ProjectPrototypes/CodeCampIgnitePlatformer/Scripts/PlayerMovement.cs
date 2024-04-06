using System;
using UnityEngine;

namespace PrototypingPlayground._003ProjectPrototypes.CodeCampIgnitePlatformer.Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        private Animator thisAnimator;
        private CharacterController thisCharacterController;
        public float jumpForce = 650;
        public float movementSpeed = 450;
        public float gravity = 1200;
        private Vector3 movement;

        private void Start()
        {
            thisAnimator = GetComponent<Animator>();
            thisCharacterController = GetComponent<CharacterController>();
            movement = Vector3.zero;
        }

        private void FixedUpdate()
        {
            if (!thisCharacterController.isGrounded)
            {
                movement += Vector3.down * gravity * Time.fixedDeltaTime;
            }
            
            if (Input.GetKey(KeyCode.RightArrow))
            {
                thisAnimator.Play("Hero Right Animation");
                movement += Vector3.right * movementSpeed * Time.fixedDeltaTime;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                thisAnimator.Play("Hero Left Animation");
                movement += Vector3.left * movementSpeed * Time.fixedDeltaTime;
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                movement = new Vector3(movement.x, jumpForce, movement.z);
            }
            thisCharacterController.Move(movement);
        }
    }
}
