using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._002StateMachine.GenericStateMachine.ExampleStates
{
    /// <summary>
    /// This state will be our second and disabled state.
    /// </summary>
    public class SecondExampleState : MonoBehaviour, IState
    {
        // The client we will be changing the states of.
        private ClientWithStates clientWithStates;
        
        // Called when the client enters this state. (We are taking in the client that we will change the state of)
        public void EnterState(ClientWithStates _clientWithStates)
        {
            clientWithStates = _clientWithStates;
            
            // This is what happens to the client when they enter this state.
            ClientEntersThisState();
        }
        
        private void ClientEntersThisState()
        {
            print("Entering State: SecondExampleState");
            clientWithStates.ExampleStringOthersSee = clientWithStates.normalString;
            clientWithStates.ExampleFloatOthersSee = clientWithStates.hiddenFloat;
            clientWithStates.CanTriggerAnAction = false;
        }
    }
}