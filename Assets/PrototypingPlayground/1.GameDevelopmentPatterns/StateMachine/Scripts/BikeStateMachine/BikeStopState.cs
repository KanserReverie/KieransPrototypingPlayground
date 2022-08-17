using UnityEngine;
namespace PrototypingPlayground._1.GameDevelopmentPatterns.StateMachine.Scripts.BikeStateMachine
{
    public class BikeStopState : MonoBehaviour, IBikeState
    {
        private BikeController _bikeController;

        public void Handle(BikeController bikeController)
        {
            if (!_bikeController)
                _bikeController = bikeController;

            _bikeController.CurrentSpeed = 0;
        }
    }
}
