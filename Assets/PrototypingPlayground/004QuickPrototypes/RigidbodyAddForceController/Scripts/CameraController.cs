using UnityEngine;
using UnityEngine.InputSystem;
namespace PrototypingPlayground._004QuickPrototypes.RigidbodyAddForceController
{
    public class CameraController : MonoBehaviour
    {
        private Vector2 cameraInput;

        private void Update()
        {
            transform.Rotate(cameraInput);
        }
        public void OnCameraMovement(InputAction.CallbackContext cameraInput)
        {
            this.cameraInput =  cameraInput.ReadValue<Vector2>();
        }
    }
}
