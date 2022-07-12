namespace PrototypingPlayground.CommandPattern.OverwriteLastPlay.Commands
{
    public abstract class MarbleCommand
    {
        private MarbleController marbleController;

        protected MarbleCommand(MarbleController _marbleController)
        {
            marbleController = _marbleController;
        }
        
        public abstract void ExecuteCommand();
    }
}
