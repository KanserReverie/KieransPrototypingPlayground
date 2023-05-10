namespace PrototypingPlayground._001GameDevelopmentPatterns._002StateMachine.GenericStateMachine
{
    // This is an interface that will be implemented by all states the client can be. 
    public interface IState
    {
        // Called when the client enters this state.
        void EnterState(ClientWithStates clientWithStates);
    }
}