namespace PrototypingPlayground._001GameDevelopmentPatterns._004CommandPattern.ReplaySystem.Commands
{
    public class TurnLeft : Command
    {
        private readonly BikeController bikeController;

        public TurnLeft(BikeController bikeController)
        {
            this.bikeController = bikeController;
        }
        
        public override void Execute()
        { 
            bikeController.Turn(BikeController.TurnDirection.Left);
        }
    }
}
