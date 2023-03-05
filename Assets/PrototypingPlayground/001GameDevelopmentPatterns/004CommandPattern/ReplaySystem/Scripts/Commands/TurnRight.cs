namespace PrototypingPlayground._001GameDevelopmentPatterns._004CommandPattern.ReplaySystem.Commands
{
    public class TurnRight : Command
    {
        private readonly BikeController bikeController;
        
        public TurnRight(BikeController _bikeController)
        {
            bikeController = _bikeController;
        }
        public override void Execute()
        {
            bikeController.Turn(BikeController.TurnDirection.Right);
        }
    }
}
