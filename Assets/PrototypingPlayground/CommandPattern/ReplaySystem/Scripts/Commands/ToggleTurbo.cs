namespace PrototypingPlayground.CommandPattern.ReplaySystem.Commands
{
    public class ToggleTurbo : Command
    {
        private readonly BikeController _bikeController;

        public ToggleTurbo(BikeController bikeController)
        {
            _bikeController = bikeController;
        }
        public override void Execute()
        {
            _bikeController.ToggleTurbo();
        }
    }
}
