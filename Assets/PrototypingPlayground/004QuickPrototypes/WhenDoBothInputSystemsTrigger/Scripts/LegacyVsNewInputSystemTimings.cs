using UnityEngine;
using UnityEngine.InputSystem;
// ReSharper disable All
#pragma warning disable 0168  // variable declared but not used.
#pragma warning disable 0219  // variable assigned but not used.
#pragma warning disable 0414  // private field assigned but not used.
namespace PrototypingPlayground._004QuickPrototypes.WhenDoBothInputSystemsTrigger
{
    /// <summary>
    /// This is to test if Legacy Input or New Input is triggered first and any frame differences.
    /// </summary>
    public partial class LegacyVsNewInputSystemTimings : MonoBehaviour
    {
        [Header("Run This Test on 'space' key?")]
        [SerializeField] private bool runThisTest;
        [SerializeField] private WhenToRunTest whenToRunTest = WhenToRunTest.BeginningOfUpdate;

        [Header("Reset with 'r'")]
        [SerializeField] private int framesBetweenActions = 0;
        [SerializeField] private bool testComplete = false;
       [SerializeField] private bool newInputActionTriggered = false;
       [SerializeField] private bool legacyInputActionTriggered = false;
        [SerializeField] private string whichPerformedFirst = "";
        
        [Header("Debug")]
        [SerializeField] private bool debugThisComponent;

        [Header("Conclusion")]
        [SerializeField] private string conclusion1 = "There are no frames between when when the legacy input system is triggered and the new input system.";
        [SerializeField] private string conclusion2 = "There is still a short time between when the when the new input system is triggered and the old input system is.";
        [SerializeField] private string conclusion3 = "If you run your actions in late update and your legacy input system in Update both will be triggered at the same time";
        
        public void TurnOnThisTest()
        {
            Debug.Log("Test Turned On - LegacyVsNewInputSystemTimings");
            runThisTest = true;
            debugThisComponent = true;
            ResetTest();
        }
        
        public void TurnOffThisTest()
        {
            Debug.Log("Test Turned Off - LegacyVsNewInputSystemTimings");
            runThisTest = false;
            debugThisComponent = false;
        }
        
        private void Update()
        {
            if (!runThisTest) return;
            
            if (!testComplete && whenToRunTest == WhenToRunTest.BeginningOfUpdate) RunTestTimingTest();
            
            if (!testComplete && Input.GetKeyDown(KeyCode.Space)) TriggerLegacyInput();
            
            if (Input.GetKeyDown(KeyCode.R)) ResetTest();
            
            if (!testComplete && whenToRunTest == WhenToRunTest.EndOfUpdate) RunTestTimingTest();
        }
        private void TriggerLegacyInput()
        {
            if (debugThisComponent) Debug.Log("Legacy Input Action Triggered");

            legacyInputActionTriggered = true;
            if (!newInputActionTriggered)
            {
                whichPerformedFirst = "legacyInputTriggeredFirst";
            }
            else
            {
                testComplete = true;
            }
        }

        private void RunTestTimingTest()
        {
            if (newInputActionTriggered)
            {
                if (!legacyInputActionTriggered) framesBetweenActions++;
                
                else if (legacyInputActionTriggered) testComplete = true;
            }
            
            if (legacyInputActionTriggered)
            {
                if (!newInputActionTriggered) framesBetweenActions++;
                else if (legacyInputActionTriggered) testComplete = true;
            }
        }
        private void ResetTest()
        {
            framesBetweenActions = 0;
            newInputActionTriggered = false;
            legacyInputActionTriggered = false;
            testComplete = false;
            whichPerformedFirst = "";
            if (debugThisComponent) Debug.Log("------------------------ Test Reset ------------------------");
        }
        public void OnFire(InputAction.CallbackContext _fireInput)
        {
            if (!runThisTest) return;
            if (testComplete) return;

            if (debugThisComponent) Debug.Log("New Input Action Triggered");
            
            newInputActionTriggered = true;
            if (!legacyInputActionTriggered)
            {
                whichPerformedFirst = "newInputTriggeredFirst";
            }
            else
            {
                testComplete = true;
            }

            if (_fireInput.performed)
            {
                if (debugThisComponent) Debug.Log("New Input Action Performed");
                if (!legacyInputActionTriggered)
                {
                    if (debugThisComponent) Debug.Log ("firePerformedBeforeLegacyInputSystem");
                }
            }
        }
    }
}
