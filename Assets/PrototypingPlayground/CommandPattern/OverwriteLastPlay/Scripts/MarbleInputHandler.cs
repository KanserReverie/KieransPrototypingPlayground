using System;
using UnityEngine;
using UnityEngine.InputSystem;
using PrototypingPlayground.CommandPattern.OverwriteLastPlay.Commands;
using TMPro;

namespace PrototypingPlayground.CommandPattern.OverwriteLastPlay
{
    public class MarbleInputHandler : MonoBehaviour
    {
        [SerializeField] private TMP_Text timerTMPText;
        [SerializeField] private float startingGameTimer = 10f;
        [Header("Initialise Marble Controller")]
        [SerializeField] private float jumpForce = 300f;
        [SerializeField] private float movementSpeed = 100f;

        private MarbleCommandInvoker marbleCommandInvoker;
        private PlayerInput playerInput;
        private MarbleController marbleController;
        
        private bool gameHasStarted;
        
        private bool jumpInput;
        private Vector2 horizontalMovementInput;

        private void Start()
        {
            marbleCommandInvoker = gameObject.AddComponent<MarbleCommandInvoker>();
            marbleController = gameObject.AddComponent<MarbleController>();
            playerInput = GetComponent<PlayerInput>();
            
            marbleCommandInvoker.Init(playerInput, marbleController, timerTMPText, startingGameTimer);
            marbleController.Init(jumpForce, movementSpeed);

            gameHasStarted = false;
            marbleCommandInvoker.PauseGameBeforeRecording();
        }

        private void Update()
        {
            if (gameHasStarted) return;

            if (Input.anyKey)
            {
                marbleCommandInvoker.StartSimulation();
                gameHasStarted = true;
            }
        }
        
        private void FixedUpdate()
        {
            if (jumpInput)
            {
                marbleCommandInvoker.ExecuteCommand(new Jump(marbleController));
                jumpInput = false;
            }

            if (horizontalMovementInput.magnitude != 0)
            {
                marbleCommandInvoker.ExecuteCommand(new HorizontalMovement(marbleController, horizontalMovementInput));
                horizontalMovementInput = Vector2.zero;
            }
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                jumpInput = true;
            }
        }
        
        public void OnMove(InputAction.CallbackContext context)
        {
            horizontalMovementInput = context.ReadValue<Vector2>();
        }
    }
}
