using UnityEngine;
using UnityEngine.InputSystem;
namespace PrototypingPlayground._004QuickPrototypes.TriggerTest
{
    public class DebugTriggerInputs : MonoBehaviour
    {
        private float leftTriggerValue;
        private float rightTriggerValue;

        private void Update()
        {
            Debug.Log($"Left Trigger Value = {leftTriggerValue} || Right Trigger Value = {rightTriggerValue}");
        }
        public void OnLeftTriggerInput(InputAction.CallbackContext leftTriggerInput)
        {
            leftTriggerValue = leftTriggerInput.ReadValue<float>();
        }
        public void OnRightTriggerInput(InputAction.CallbackContext rightTriggerInput)
        {
            rightTriggerValue = rightTriggerInput.ReadValue<float>();
        }
    }
}
