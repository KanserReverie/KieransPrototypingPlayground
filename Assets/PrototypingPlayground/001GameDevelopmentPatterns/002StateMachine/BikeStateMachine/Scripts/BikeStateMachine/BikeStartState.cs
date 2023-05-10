using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._002StateMachine.BikeStateMachine.BikeStateMachine
{
    public class BikeStartState : MonoBehaviour, IBikeState
    {
        private BikeController bikeController;

        public void Handle(BikeController bikeController)
        {
            if (this.bikeController == null)
            {
                this.bikeController = bikeController;
            }

            this.bikeController.CurrentSpeed = this.bikeController.maxSpeed; 
        }

        private void Update()
        {
            if (!bikeController)
                return;
            if (!(bikeController.CurrentSpeed > 0))
                return;
            bikeController.transform.Translate(Vector3.forward * (bikeController.CurrentSpeed * Time.deltaTime));
        }
    }
}
