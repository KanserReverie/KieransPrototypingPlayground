using System.Collections.Generic;
using PrototypingPlayground.CommandPattern.OverwriteLastPlay.Commands;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
namespace PrototypingPlayground.CommandPattern.OverwriteLastPlay
{
    public class MarbleCommandInvoker : MonoBehaviour
    {
        private bool weAreRecording;
        private bool weAreReplaying;
        private bool gameHasStarted;
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private MarbleController marbleController;
        [SerializeField] private TMP_Text timerTMPText;
        [SerializeField] private float startingGameTimer = 10f;
        private float currentGameTimer;

        private readonly SortedList<float, AbstractMarbleCommand> recordedCommands = new SortedList<float, AbstractMarbleCommand>();
        private float playTime;

        private AbstractMarbleCommand jump, horizontalMovement, spawnMarbleCommand;
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
            HasTheGameStarted();
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
        }

        #region Plumbing
        
        private void AddMarbleCommands()
        {
            jump = new Jump(marbleController);
            spawnMarbleCommand = new Respawn(marbleController);
        }

        private void RestartSimulation()
        {
            currentGameTimer = startingGameTimer;
            timerTMPText.text = ($"{currentGameTimer}");
            playerInput.actions.Disable();
            spawnMarbleCommand.ExecuteCommand();
            weAreRecording = false;
            gameHasStarted = false;
            Time.timeScale = 0;
        }
        private void PauseGameBeforeRecording()
        {
            currentGameTimer = startingGameTimer;
            timerTMPText.text = ($"{currentGameTimer}");
            playerInput.actions.Disable();
            weAreRecording = false;
            gameHasStarted = false;
            Time.timeScale = 0;
        }
        
        private void HandleTime()
        {
            timerTMPText.text = ($"{currentGameTimer}");
            if (weAreRecording)
            {
                playTime += Time.fixedDeltaTime;
            }

            if (currentGameTimer > 0)
            {
                currentGameTimer -= Time.fixedDeltaTime;
            }
            if (currentGameTimer <= 0)
            {
                currentGameTimer = 0;
                RestartSimulation();
            }
        }
        
        private void HasTheGameStarted()
        {
            if (gameHasStarted) return;
            Debug.Log($"gameHasStarted = {gameHasStarted}");

            if (Input.anyKey)
            {
                Time.timeScale = 1;
                playerInput.actions.Enable();
                weAreRecording = true;
                gameHasStarted = true;
                playTime = 0;
            }
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

            AbstractMarbleCommand thisMovement = new HorizontalMovement(marbleController, horizontalMovementInput);
            
            if (weAreRecording)
            {
                recordedCommands.Add(playTime, thisMovement);
            }

            thisMovement.ExecuteCommand();

            horizontalMovementInput = Vector2.zero;
        }
        
        #endregion
    }
}
