namespace PrototypingPlayground._001GameDevelopmentPatterns._002StateMachine.BikeStateMachine.BikeStateMachine
{
    public class BikeStateContext
    {
        public IBikeState CurrentState { get; set; }
        
        private readonly BikeController bikeController;

        public BikeStateContext(BikeController _bikeController)
        {
            bikeController = _bikeController;
        }

        public void Transition()
        {
            CurrentState.Handle(bikeController);
        }
        public void Transition(IBikeState _bikeState)
        {
            CurrentState = _bikeState;
            CurrentState.Handle(bikeController);
        }
    }
}
