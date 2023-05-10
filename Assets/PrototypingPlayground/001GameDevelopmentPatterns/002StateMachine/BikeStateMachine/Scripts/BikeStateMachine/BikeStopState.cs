using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._002StateMachine.BikeStateMachine.BikeStateMachine
{
    public class BikeStopState : MonoBehaviour, IBikeState
    {
        private BikeController bikeController;

        public void Handle(BikeController bikeController)
        {
            if (!this.bikeController)
                this.bikeController = bikeController;

            this.bikeController.CurrentSpeed = 0;
        }
    }
}
