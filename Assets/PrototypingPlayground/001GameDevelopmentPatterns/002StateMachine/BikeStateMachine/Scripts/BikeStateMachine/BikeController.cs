using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._002StateMachine.BikeStateMachine.BikeStateMachine
{
    public class BikeController : MonoBehaviour
    {
        public float maxSpeed = 2.0f;
        public float turningDistance = 2.0f;
        
        public float CurrentSpeed { get; set; }
        
        public Direction CurrentDirection { get; private set; }

        private IBikeState startState, stopState, turnState;
        private BikeStateContext bikeStateContext;

        private void Start()
        {
            bikeStateContext = new BikeStateContext(this);
            
            startState = gameObject.AddComponent<BikeStartState>();
            stopState = gameObject.AddComponent<BikeStopState>();
            turnState = gameObject.AddComponent<BikeTurnState>();
            
            bikeStateContext.Transition(stopState);
        }

        public void StartBike()
        {
            bikeStateContext.Transition(startState);
        }
        public void StopBike()
        {
            bikeStateContext.Transition(stopState);
        }
        public void TurnBike(Direction direction)
        {
            CurrentDirection = direction;
            bikeStateContext.Transition(turnState);
        }
    }
}
