using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._002StateMachine.BikeStateMachine.BikeStateMachine
{
    public class BikeTurnState : MonoBehaviour, IBikeState
    {
        private BikeController bikeController;

        private Vector3 turningDirection;
        
        public void Handle(BikeController bikeController)
        {
            if (!this.bikeController)
                this.bikeController = bikeController;

            turningDirection.x = (float)this.bikeController.CurrentDirection;

            if (!(this.bikeController.CurrentSpeed > 0))
                return;
            if((Mathf.Abs(transform.position.x + (turningDirection.x * this.bikeController.turningDistance)) > 4f))
                return;
            this.bikeController.transform.Translate(turningDirection * this.bikeController.turningDistance);
        }
    }
}
