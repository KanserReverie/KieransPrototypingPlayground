namespace PrototypingPlayground.CommandPattern.RewindSystem.Scripts
{
    public abstract class Command
    {
        private readonly PlayerMovementController playerMovementController;
        
        protected Command(PlayerMovementController _playerMovementController)
        {
            playerMovementController = _playerMovementController;
        }
        
        public abstract void Execute();
        
        public abstract void Undo();
    }
}
