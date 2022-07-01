namespace PrototypingPlayground.CommandPattern.Commands
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
