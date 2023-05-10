using PrototypingPlayground._001GameDevelopmentPatterns._002StateMachine.GenericStateMachine.ExampleStates;
using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._002StateMachine.GenericStateMachine
{
    /// <summary>
    /// This is an example Player with 3 simple states.
    /// </summary>
    public class ClientWithStates : MonoBehaviour
    {
        // These are all variables that will be changed depending on the state this is in.
        public string ExampleStringOthersSee { get; set; }
        public float ExampleFloatOthersSee { get; set;}
        public bool CanTriggerAnAction { get; set;}
        
        public string normalString = "Player 1";
        public string unknownSting = "????????";
        public float normalFloat = 2;
        public float hiddenFloat;
        
        private IState firstExampleState, secondExampleState, thirdExampleState;

        private StateMachine stateMachine;

        public void Start()
        {
            // Add the state machine.
            stateMachine = new StateMachine(this);

            // Add all the states we can transition between.
            firstExampleState = gameObject.AddComponent<FirstExampleState>();
            secondExampleState = gameObject.AddComponent<SecondExampleState>();
            thirdExampleState = gameObject.AddComponent<ThirdExampleState>();
            
            // Sets the first state.
            stateMachine.ChangeState(firstExampleState);
        }

        public void Update()
        {
            // When we press 1,2,3 Keys we will transition the the respective state if we are not already in it.
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                // Enter first state.
                if (stateMachine.CurrentState != firstExampleState)
                {
                    stateMachine.ChangeState(firstExampleState);
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                // Enter second state.
                if (stateMachine.CurrentState != secondExampleState)
                {
                    stateMachine.ChangeState(secondExampleState);
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                // Enter third state.
                if (stateMachine.CurrentState != thirdExampleState)
                {
                    stateMachine.ChangeState(thirdExampleState);
                }
            }
        }
    }
}