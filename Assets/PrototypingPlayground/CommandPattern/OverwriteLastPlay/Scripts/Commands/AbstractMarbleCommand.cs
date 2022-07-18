using UnityEngine;
namespace PrototypingPlayground.CommandPattern.OverwriteLastPlay.Commands
{
    public abstract class AbstractMarbleCommand
    {
        protected readonly MarbleController marbleController;

        protected AbstractMarbleCommand(MarbleController _marbleController)
        {
            marbleController = _marbleController;
        }
        
        public virtual void ExecuteCommand() { }
    }
}
