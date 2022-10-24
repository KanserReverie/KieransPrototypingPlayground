namespace PrototypingPlayground._001GameDevelopmentPatterns._002StateMachine.BikeStateMachine
{
    public class BikeStateContext
    {
        public IBikeState CurrentState { get; set; }
        
        private readonly BikeController _bikeController;

        public BikeStateContext(BikeController bikeController)
        {
            _bikeController = bikeController;
        }

        public void Transition()
        {
            CurrentState.Handle(_bikeController);
        }
        public void Transition(IBikeState bikeState)
        {
            CurrentState = bikeState;
            CurrentState.Handle(_bikeController);
        }
    }
}
