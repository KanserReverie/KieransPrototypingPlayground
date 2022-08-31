namespace PrototypingPlayground._1.GameDevelopmentPatterns._4.CommandPattern.ReplaySystem.Commands
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