namespace PrototypingPlayground.CommandPattern.RewindSystem.Scripts
{
    public class ChangeColour : Command
    {
        private readonly PlayerMovementController playerMovementController;

        public ChangeColour(PlayerMovementController _playerMovementController) : base(_playerMovementController)
        {
            playerMovementController = _playerMovementController;
        }
        
        public override void Execute()
        {
            playerMovementController.NextColour();
        }
        
        public override void Undo()
        {
            playerMovementController.PreviousColour();
        }
    }
}
