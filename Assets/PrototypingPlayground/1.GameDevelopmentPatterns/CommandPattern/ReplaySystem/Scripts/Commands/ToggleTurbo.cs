namespace PrototypingPlayground._1.GameDevelopmentPatterns.CommandPattern.ReplaySystem.Scripts.Commands
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
