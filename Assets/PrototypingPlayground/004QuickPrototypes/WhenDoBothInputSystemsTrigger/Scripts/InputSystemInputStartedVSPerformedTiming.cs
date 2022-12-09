using UnityEngine;
using UnityEngine.InputSystem;
// ReSharper disable NotAccessedField.Local

namespace PrototypingPlayground._004QuickPrototypes.WhenDoBothInputSystemsTrigger
{
    /// <summary>
    /// This is to test the difference between when an action is started vs performed.
    /// </summary>
    public class InputSystemInputStartedVSPerformedTiming : MonoBehaviour
    {
        private bool fireInputPressedButFireNotPerformed;
        
        [Header("Run This Test on 'space' key?")]
        [SerializeField] private bool runThisTest;
        
        [Header("Reset with 'r'")]
        [SerializeField] private int framesBetweenActions = 0;
        [SerializeField] private int onFireFullCycles = 0;
        [SerializeField] private bool firstActionTriggered = false;
        [SerializeField] private bool secondActionTriggered = false;
        [SerializeField] private bool testComplete = false;
        
        [Header("Debug")]
        [SerializeField] private bool debugThisComponent;
        
        [Header("Conclusion")]
        [SerializeField] private string conclusion1 = "There are no frames between when when the New Input System first triggers a the action is performed.";
        [SerializeField] private string conclusion2 = "It will go through 1 full cycle before the action is performed.";

        public void TurnOnThisTest()
        {
            Debug.Log("Test Turned On - InputSystemInputStaredVSPerformedTiming");
            runThisTest = true;
            debugThisComponent = true;
            ResetTest();
        }
        
        public void TurnOffThisTest()
        {
            Debug.Log("Test Turned Off - InputSystemInputStaredVSPerformedTiming");
            runThisTest = false;
            debugThisComponent = false;
        }

        private void Update()
        {
            if (!runThisTest) return;
            
            if (!testComplete) RunTestTimingTest();
            
            if (Input.GetKeyDown(KeyCode.R)) ResetTest();
        }
        
        private void RunTestTimingTest()
        {
            if (firstActionTriggered)
            {
                if (!secondActionTriggered)
                {
                    framesBetweenActions++;
                }
                else if (secondActionTriggered)
                {
                    testComplete = true;
                }
            }
            
        }
        private void ResetTest()
        {
            framesBetweenActions = 0;
            onFireFullCycles = 0;
            firstActionTriggered = false;
            secondActionTriggered = false;
            testComplete = false;
            if (debugThisComponent) Debug.Log("------------------------ Test Reset ------------------------");
            
        }

        public void OnFire(InputAction.CallbackContext _fireInput)
        {
            if (!runThisTest) return;

            if (!testComplete)
            {
                if (debugThisComponent) Debug.Log("First Action Triggered");
                firstActionTriggered = true;

                if (_fireInput.performed)
                {
                    secondActionTriggered = true;
                    if (debugThisComponent) Debug.Log("Second Action Triggered");
                }
                else
                {
                    onFireFullCycles++;
                }
            }
        }
    }
}