namespace PrototypingPlayground._001GameDevelopmentPatterns._002StateMachine.GenericStateMachine
{
    // This is the state machine that will handle the current state and state transitions.
    public class StateMachine
    {
        // Current state we are in.
        public IState CurrentState { get; private set; }

        // The client this state manchine will be linked to.
        // We make sure of this by having them in the constructor.
        private readonly ClientWithStates clientWithStates;

        // Our constructor, making sure to take in and set our client.
        public StateMachine(ClientWithStates _clientWithStates)
        {
            clientWithStates = _clientWithStates;
        }
        
        // This handles transitioning the client between states.
        // This make sure the "entering" method will be called when changing state. 
        public void ChangeState(IState _newState)
        {
            // Changes the state.
            CurrentState = _newState;
            // Calls the new state EnterState() method.
            _newState.EnterState(clientWithStates);
        }
    }
}