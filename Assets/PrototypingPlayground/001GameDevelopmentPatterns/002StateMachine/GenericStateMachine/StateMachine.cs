namespace PrototypingPlayground._001GameDevelopmentPatterns._002StateMachine.GenericStateMachine
{
    public class StateMachine
    {
        public IState CurrentState { get; set; }

        private readonly ClientWithStates clientWithStates;

        public StateMachine(ClientWithStates _clientWithStates)
        {
            clientWithStates = _clientWithStates;
        }

        public void ChangeState(IState _newState)
        {
            CurrentState = _newState;
            
            _newState.EnterState(clientWithStates);
        }
    }
}