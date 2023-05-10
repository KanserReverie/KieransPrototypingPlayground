using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._002StateMachine.GenericStateMachine.ExampleStates
{
    /// <summary>
    /// This state will be our first and default state.
    /// </summary>
    public class FirstExampleState : MonoBehaviour, IState
    {
        // The client we will be changing the states of.
        private ClientWithStates clientWithStates;

        // Called when the client enters this state. (We are taking in the client that we will change the state of)
        public void EnterState(ClientWithStates clientWithStates)
        {
            this.clientWithStates = clientWithStates;
            
            // This is what happens to the client when they enter this state.
            ClientEntersThisState();
        }
        
        private void ClientEntersThisState()
        {
            print("Entering State: FirstExampleState");
            clientWithStates.ExampleStringOthersSee = clientWithStates.normalString;
            clientWithStates.ExampleFloatOthersSee = clientWithStates.normalFloat;
            clientWithStates.CanTriggerAnAction = true;
        }
    }
}