using UnityEngine;
using UnityEngine.InputSystem;

namespace PrototypingPlayground.QuickPrototypes.TriggerTest
{
    public class DebugTriggerInputs : MonoBehaviour
    {
        private float leftTriggerValue;
        private float rightTriggerValue;

        private void Update()
        {
            Debug.Log($"Left Trigger Value = {leftTriggerValue} || Right Trigger Value = {rightTriggerValue}");
        }
        public void OnLeftTriggerInput(InputAction.CallbackContext _leftTriggerInput)
        {
            leftTriggerValue = _leftTriggerInput.ReadValue<float>();
        }
        public void OnRightTriggerInput(InputAction.CallbackContext _rightTriggerInput)
        {
            rightTriggerValue = _rightTriggerInput.ReadValue<float>();
        }
    }
}
