using System;
using UnityEngine;
namespace PrototypingPlayground._004QuickPrototypes.WhenDoBothInputSystemsTrigger
{
    public class TestToRun : MonoBehaviour
    {
        [SerializeField] private Tests testYouWantToRun;
        private Tests previousTestYouWantToRun;

        public void Start()
        {
            Debug.Log("--------------- ABOUT ---------------");
            Debug.Log("This scene is used to test: \n Timings between different Inputs & Input Systems |AND| Delays and/or frame drops between them  :)");
            Debug.Log("-------------------------------------");
            ChangeTestTurnedOn(testYouWantToRun);
        }

        private void ChangeTestTurnedOn(Tests test)
        {
            switch (test)
            {
                case Tests.NoTest:
                    FindObjectOfType<LegacyVsNewInputSystemTimings>().TurnOffThisTest();
                    FindObjectOfType<InputSystemInputStartedVSPerformedTiming>().TurnOffThisTest();
                    break;

                case Tests.InputSystemInputStartedVSPerformedTiming:
                    FindObjectOfType<InputSystemInputStartedVSPerformedTiming>().TurnOnThisTest();
                    FindObjectOfType<LegacyVsNewInputSystemTimings>().TurnOffThisTest();
                    break;

                case Tests.LegacyVsNewInputSystemTimings:
                    FindObjectOfType<LegacyVsNewInputSystemTimings>().TurnOnThisTest();
                    FindObjectOfType<InputSystemInputStartedVSPerformedTiming>().TurnOffThisTest();
                    break;
                case Tests.Both:
                    FindObjectOfType<LegacyVsNewInputSystemTimings>().TurnOnThisTest();
                    FindObjectOfType<InputSystemInputStartedVSPerformedTiming>().TurnOnThisTest();
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
            previousTestYouWantToRun = testYouWantToRun;
        }

        private void Update()
        {
            if (testYouWantToRun != previousTestYouWantToRun)
            {
                ChangeTestTurnedOn(testYouWantToRun);
            }
        }
    }
}