using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._002StateMachine.BikeStateMachine.BikeStateMachine
{
    public class BikeStopState : MonoBehaviour, IBikeState
    {
        private BikeController bikeController;

        public void Handle(BikeController _bikeController)
        {
            if (!bikeController)
                bikeController = _bikeController;

            bikeController.CurrentSpeed = 0;
        }
    }
}
