namespace PrototypingPlayground._001GameDevelopmentPatterns._004CommandPattern.MarbleReplaySystem.Commands
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
