namespace PrototypingPlayground._001GameDevelopmentPatterns._004CommandPattern.ReplaySystem.Commands
{
    public class ToggleTurbo : Command
    {
        private readonly BikeController bikeController;

        public ToggleTurbo(BikeController _bikeController)
        {
            bikeController = _bikeController;
        }
        public override void Execute()
        {
            bikeController.ToggleTurbo();
        }
    }
}
