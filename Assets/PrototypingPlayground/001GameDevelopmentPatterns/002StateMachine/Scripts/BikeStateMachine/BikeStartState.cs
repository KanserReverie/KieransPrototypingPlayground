using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._002StateMachine.BikeStateMachine
{
    public class BikeStartState : MonoBehaviour, IBikeState
    {
        private BikeController _bikeController;

        public void Handle(BikeController bikeController)
        {
            if (_bikeController == null)
            {
                _bikeController = bikeController;
            }

            _bikeController.CurrentSpeed = _bikeController.maxSpeed; 
        }

        private void Update()
        {
            if (!_bikeController)
                return;
            if (!(_bikeController.CurrentSpeed > 0))
                return;
            _bikeController.transform.Translate(Vector3.forward * (_bikeController.CurrentSpeed * Time.deltaTime));
        }
    }
}
