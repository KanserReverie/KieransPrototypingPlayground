using System.Collections.Generic;
using PrototypingPlayground.CommandPattern.OverwriteLastPlay.Commands;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
namespace PrototypingPlayground.CommandPattern.OverwriteLastPlay
{
    public class MarbleCommandInvoker : MonoBehaviour
    {
        private bool areWeRecording;
        private bool hasGameStarted;
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private MarbleController marbleController;

        private List<MarbleCommand> listOfMarbleCommands= new List<MarbleCommand>();
        
        private void Start()
        {
            marbleController = FindObjectOfType<MarbleController>();
            AddMarbleCommands();
            PauseGameBeforeRecording();
        }
        private void AddMarbleCommands()
        {
            listOfMarbleCommands.Add(new JumpCommand(marbleController));
        }
        private void PauseGameBeforeRecording()
        {
            playerInput.actions.Disable();
            areWeRecording = false;
            hasGameStarted = false;
            Time.timeScale = 0;
        }

        private void Update()
        {
            if (HasTheGameStarted()) return;
        }
        
        private bool HasTheGameStarted()
        {
            if (hasGameStarted) return true;
            
            if (Input.anyKey)
            {
                Time.timeScale = 1;
                playerInput.actions.Enable();
                areWeRecording = true;
                hasGameStarted = true;
                return true;
            }
            return false;
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                listOfMarbleCommands[0].ExecuteCommand();
            }
        }
    }
}
