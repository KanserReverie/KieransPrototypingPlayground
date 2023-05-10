namespace PrototypingPlayground._001GameDevelopmentPatterns._002StateMachine.BikeStateMachine.BikeStateMachine
{
    public class BikeStateContext
    {
        public IBikeState CurrentState { get; set; }
        
        private readonly BikeController bikeController;

        public BikeStateContext(BikeController bikeController)
        {
            this.bikeController = bikeController;
        }

        public void Transition()
        {
            CurrentState.Handle(bikeController);
        }
        public void Transition(IBikeState bikeState)
        {
            CurrentState = bikeState;
            CurrentState.Handle(bikeController);
        }
    }
}
