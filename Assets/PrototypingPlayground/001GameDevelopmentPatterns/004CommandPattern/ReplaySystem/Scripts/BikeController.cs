using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._004CommandPattern.ReplaySystem
{
    public class BikeController : MonoBehaviour
    {
        public enum TurnDirection
        {
            Left = -1,
            Right = 1
        }

        private bool isTurboOn;
        private float distance = 1.0f;
        [SerializeField] private float turboSpeed = 1.0f;

        public void TurnOffTurbo() => isTurboOn = false;

        public void ToggleTurbo()
        {
            isTurboOn = !isTurboOn;
            Debug.Log("Turbo Active: " + isTurboOn.ToString());
        }
        public void FixedUpdate()
        {
            if(isTurboOn)
                transform.Translate(Vector3.forward * turboSpeed * Time.fixedDeltaTime);
        }

        public void Turn(TurnDirection direction)
        {
            if (direction == TurnDirection.Left) 
                transform.Translate(Vector3.left * distance);
        
            if (direction == TurnDirection.Right)
                transform.Translate(Vector3.right * distance);
        }

        public void ResetPosition()
        {
            transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }
}
