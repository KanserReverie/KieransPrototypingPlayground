using System.Collections.Generic;
using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._004CommandPattern.GenericCommandPattern
{
    /// <summary>
    /// This will handle all the commands and execute them.
    /// </summary>
    public class CommandManager : MonoBehaviour
    {
        private readonly Stack<ICommand> commandStack = new Stack<ICommand>();

        public void ExecuteCommand(ICommand command)
        {
            command.ExecuteCommand();
            commandStack.Push(command);
        }

        public void UndoLastCommand()
        {
            if (commandStack.Count <= 0) return;
            ICommand command = commandStack.Pop();
            command.Undo();
        }
    }
}