using PrototypingPlayground._001GameDevelopmentPatterns._004CommandPattern.MarbleReplaySystem.Commands;
using PrototypingPlayground.UsefulScripts;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PrototypingPlayground._001GameDevelopmentPatterns._004CommandPattern.MarbleReplaySystem
{
    public class MarbleInputHandler : MonoBehaviour
    {
        [Header("Canvas Text")]
        [SerializeField] private TMP_Text timerTMPText;
        [SerializeField] private float startingGameTimer = 10f;
        [SerializeField] private TMP_Text statusTMPText;
        [Header("Initialise Marble Controller")]
        [SerializeField] private float jumpForce = 300f;
        [SerializeField] private float movementSpeed = 100f;
        [SerializeField] private float playerGravity = 9.81f;

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
            
            marbleCommandInvoker.Init(playerInput, marbleController, timerTMPText, statusTMPText,startingGameTimer);
            marbleController.Init(jumpForce, movementSpeed,playerGravity);

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
            if (marbleCommandInvoker.WeAreReplaying) return;
            
            if (jumpInput)
            {
                marbleCommandInvoker.ExecuteCommand(new Jump(marbleController));
                jumpInput = false;
            }

            if (horizontalMovementInput.magnitude != 0)
            {
                marbleCommandInvoker.ExecuteCommand(new HorizontalMovement(marbleController, horizontalMovementInput));
            }
        }

        public void OnJump(InputAction.CallbackContext _context)
        {
            if (_context.started)
            {
                jumpInput = true;
            }
        }
        
        public void OnMove(InputAction.CallbackContext _context)
        {
            horizontalMovementInput = _context.ReadValue<Vector2>();
        }

        public void OnQuit(InputAction.CallbackContext _context)
        {
            CommonlyUsedStaticMethods.QuitGame();
        }
    }
}
