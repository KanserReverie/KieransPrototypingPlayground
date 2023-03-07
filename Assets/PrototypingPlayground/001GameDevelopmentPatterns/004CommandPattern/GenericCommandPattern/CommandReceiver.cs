using System;
using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._004CommandPattern.GenericCommandPattern
{
    /// <summary>
    /// The commands will invoke changes on this class.
    /// </summary>
    [RequireComponent(typeof(InputController))]
    [RequireComponent(typeof(CommandManager))]
    public class CommandReceiver : MonoBehaviour
    {
        public void FirstCommand()
        {
            Debug.Log("First Command");
        }
        public void UndoFirstCommand()
        {
            Debug.Log("Undo First Command");
        }
        
        public void SecondCommand()
        {
            Debug.Log("Second Command");
        }
        
        public void UndoSecondCommand()
        {
            Debug.Log("Undo Second Command");
        }
        
        public void ThirdCommand()
        {
            Debug.Log("Third Command");
        }
        
        public void UndoThirdCommand()
        {
            Debug.Log("Undo Third Command");
        }
    }
}