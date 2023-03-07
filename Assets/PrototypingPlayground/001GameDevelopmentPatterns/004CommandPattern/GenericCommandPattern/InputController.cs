using System;
using PrototypingPlayground._001GameDevelopmentPatterns._004CommandPattern.GenericCommandPattern.ExampleCommands;
using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._004CommandPattern.GenericCommandPattern
{
    /// <summary>
    /// This will call your commands from the command manager.
    /// Normally linked to your Player Input System.
    /// </summary>
    public class InputController : MonoBehaviour
    {
        private CommandManager commandManager;
        private CommandReceiver commandReceiver;
        private void Awake()
        {
            commandManager = GetComponentInChildren<CommandManager>();
            commandReceiver = GetComponentInChildren<CommandReceiver>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                commandManager.ExecuteCommand(new FirstExampleCommand(commandReceiver));
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                commandManager.ExecuteCommand(new SecondExampleCommand(commandReceiver));
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                commandManager.ExecuteCommand(new ThirdExampleCommand(commandReceiver));
            }
            
            if (Input.GetKeyDown(KeyCode.Z))
            {
                commandManager.UndoLastCommand();
            }
        }
    }
}