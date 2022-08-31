using UnityEngine;
namespace PrototypingPlayground._1.GameDevelopmentPatterns._4.CommandPattern.ReplaySystem
{
    public class BikeController : MonoBehaviour
    {
        public enum TurnDirection
        {
            Left = -1,
            Right = 1
        }

        private bool _isTurboOn;
        private float _distance = 1.0f;
        [SerializeField] private float turboSpeed = 1.0f;

        public void TurnOffTurbo() => _isTurboOn = false;

        public void ToggleTurbo()
        {
            _isTurboOn = !_isTurboOn;
            Debug.Log("Turbo Active: " + _isTurboOn.ToString());
        }
        public void FixedUpdate()
        {
            if(_isTurboOn)
                transform.Translate(Vector3.forward * turboSpeed * Time.fixedDeltaTime);
        }

        public void Turn(TurnDirection direction)
        {
            if (direction == TurnDirection.Left) 
                transform.Translate(Vector3.left * _distance);
        
            if (direction == TurnDirection.Right)
                transform.Translate(Vector3.right * _distance);
        }

        public void ResetPosition()
        {
            transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }
}
