using System;
using UnityEngine;
using UnityEngine.InputSystem;
namespace PrototypingPlayground.QuickPrototypes.RigidbodyAddForceController
{
    public class CameraController : MonoBehaviour
    {
        private Vector2 cameraInput;

        private void Update()
        {
            transform.Rotate(cameraInput);
        }
        public void OnCameraMovement(InputAction.CallbackContext _cameraInput)
        {
            cameraInput =  _cameraInput.ReadValue<Vector2>();
        }
    }
}
