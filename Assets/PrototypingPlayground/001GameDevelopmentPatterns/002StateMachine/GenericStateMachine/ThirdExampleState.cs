using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._002StateMachine.GenericStateMachine
{
    public class ThirdExampleState: MonoBehaviour, IState
    {
        private ClientWithStates clientWithStates;

        public void EnterState(ClientWithStates _clientWithStates)
        {
            clientWithStates = _clientWithStates;

            // Enter what entering this state will do to the client.
            // In this case lets change the clients movementSpeed to Max.
        }

    }
}