namespace PrototypingPlayground._1.GameDevelopmentPatterns.CommandPattern.ReplaySystem.Scripts.Commands
{
    public class TurnRight : Command
    {
        private readonly BikeController _bikeController;
        
        public TurnRight(BikeController bikeController)
        {
            _bikeController = bikeController;
        }
        public override void Execute()
        {
            _bikeController.Turn(BikeController.TurnDirection.Right);
        }
    }
}
