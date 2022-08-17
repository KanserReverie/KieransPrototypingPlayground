namespace PrototypingPlayground._1.GameDevelopmentPatterns.CommandPattern.ReplaySystem.Scripts.Commands
{
    public class TurnLeft : Command
    {
        private readonly BikeController _bikeController;

        public TurnLeft(BikeController bikeController)
        {
            _bikeController = bikeController;
        }
        
        public override void Execute()
        { 
            _bikeController.Turn(BikeController.TurnDirection.Left);
        }
    }
}
