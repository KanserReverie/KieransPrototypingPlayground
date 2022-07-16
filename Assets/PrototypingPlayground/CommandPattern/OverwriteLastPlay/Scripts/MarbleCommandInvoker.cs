using System.Collections.Generic;
using PrototypingPlayground.CommandPattern.OverwriteLastPlay.Commands;
using UnityEngine;
using UnityEngine.InputSystem;
namespace PrototypingPlayground.CommandPattern.OverwriteLastPlay
{
    public class MarbleCommandInvoker : MonoBehaviour
    {
        private bool weAreRecording;
        private bool gameHasStarted;
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private MarbleController marbleController;

        private readonly SortedList<float, AbstractMarbleCommand> recordedCommands = new SortedList<float, AbstractMarbleCommand>();
        private float playTime;

        private AbstractMarbleCommand jump, horizontalMovement;

        private bool jumpInput;
        private Vector2 horizontalMovementInput;

        private void Start()
        {
            marbleController = FindObjectOfType<MarbleController>();
            AddMarbleCommands();
            PauseGameBeforeRecording();
        }

        private void Update()
        {
            if (HasTheGameStarted()) return;
        }
        private void FixedUpdate()
        {
            if (!gameHasStarted) return;
            ExecutePlayerMovement();
            HandleTime();
        }

        private void ExecutePlayerMovement()
        {
            ExecuteJumpCommand();
            ExecuteHorizontalMovementCommand();
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
            Debug.Log($"horizontalMovementInput = {horizontalMovementInput}");
        }

        #region Plumbing
        private void AddMarbleCommands()
        {
            jump = new JumpMarbleCommand(marbleController);
            horizontalMovement = new HorizontalMovementMarbleCommand(marbleController);
        }
        private void PauseGameBeforeRecording()
        {
            playerInput.actions.Disable();
            weAreRecording = false;
            gameHasStarted = false;
            Time.timeScale = 0;
        }
        private void HandleTime()
        {
            if (weAreRecording)
            {
                playTime += Time.fixedDeltaTime;
            }
        }
        private bool HasTheGameStarted()
        {
            if (gameHasStarted) return true;

            if (Input.anyKey)
            {
                Time.timeScale = 1;
                playerInput.actions.Enable();
                weAreRecording = true;
                gameHasStarted = true;
                playTime = 0;
                return true;
            }
            return false;
        }
        private void ExecuteJumpCommand()
        {
            if (!jumpInput) return;

            if (weAreRecording)
            {
                recordedCommands.Add(playTime, jump);
            }

            jump.ExecuteCommand();

            jumpInput = false;
        }
        private void ExecuteHorizontalMovementCommand()
        {
            if (horizontalMovementInput.magnitude == 0) return;

            if (weAreRecording)
            {
                recordedCommands.Add(playTime, horizontalMovement);
            }

            horizontalMovement.ExecuteCommand(horizontalMovementInput);

            horizontalMovementInput = Vector2.zero;
        }
        #endregion
    }
}
