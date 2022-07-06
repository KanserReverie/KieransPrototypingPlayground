namespace PrototypingPlayground.CommandPattern.RewindSystem.Scripts
{
    public class ChangeColour : Command
    {
        private PlayerMovementController _playerMovementController;

        public ChangeColour(PlayerMovementController playerMovementController)
        {
            _playerMovementController = playerMovementController;
        }


        public override void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
