using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._002StateMachine.BikeStateMachine.BikeStateMachine
{
    public class BikeTurnState : MonoBehaviour, IBikeState
    {
        private BikeController bikeController;

        private Vector3 turningDirection;
        
        public void Handle(BikeController _bikeController)
        {
            if (!bikeController)
                bikeController = _bikeController;

            turningDirection.x = (float)bikeController.CurrentDirection;

            if (!(bikeController.CurrentSpeed > 0))
                return;
            if((Mathf.Abs(transform.position.x + (turningDirection.x * bikeController.turningDistance)) > 4f))
                return;
            bikeController.transform.Translate(turningDirection * bikeController.turningDistance);
        }
    }
}
