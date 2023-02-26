using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._002StateMachine.BikeStateMachine.BikeStateMachine
{
    public class BikeStartState : MonoBehaviour, IBikeState
    {
        private BikeController bikeController;

        public void Handle(BikeController _bikeController)
        {
            if (bikeController == null)
            {
                bikeController = _bikeController;
            }

            bikeController.CurrentSpeed = bikeController.maxSpeed; 
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
