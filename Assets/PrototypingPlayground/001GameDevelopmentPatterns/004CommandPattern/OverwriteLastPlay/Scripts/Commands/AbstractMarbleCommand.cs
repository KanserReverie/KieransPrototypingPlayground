namespace PrototypingPlayground._001GameDevelopmentPatterns._004CommandPattern.OverwriteLastPlay.Commands
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
