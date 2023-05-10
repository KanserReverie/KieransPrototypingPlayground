namespace PrototypingPlayground._001GameDevelopmentPatterns._004CommandPattern.MarbleReplaySystem.Commands
{
    public abstract class AbstractMarbleCommand
    {
        protected readonly MarbleController MarbleController;

        protected AbstractMarbleCommand(MarbleController marbleController)
        {
            MarbleController = marbleController;
        }
        
        public virtual void ExecuteCommand() { }
    }
}
