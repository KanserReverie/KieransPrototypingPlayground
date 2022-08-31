using UnityEngine;
namespace PrototypingPlayground._1.GameDevelopmentPatterns._2.StateMachine.BikeStateMachine
{
    public class BikeTurnState : MonoBehaviour, IBikeState
    {
        private BikeController _bikeController;

        private Vector3 _turningDirection;
        
        public void Handle(BikeController bikeController)
        {
            if (!_bikeController)
                _bikeController = bikeController;

            _turningDirection.x = (float)_bikeController.CurrentDirection;

            if (!(_bikeController.CurrentSpeed > 0))
                return;
            if((Mathf.Abs(transform.position.x + (_turningDirection.x * _bikeController.turningDistance)) > 4f))
                return;
            _bikeController.transform.Translate(_turningDirection * _bikeController.turningDistance);
        }
    }
}
