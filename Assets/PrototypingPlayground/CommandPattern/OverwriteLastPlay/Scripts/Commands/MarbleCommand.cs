namespace PrototypingPlayground.CommandPattern.OverwriteLastPlay.Commands
{
    public abstract class MarbleCommand
    {
        protected MarbleController marbleController;

        protected MarbleCommand(MarbleController _marbleController)
        {
            marbleController = _marbleController;
        }
        
        public abstract void ExecuteCommand();
    }
}
