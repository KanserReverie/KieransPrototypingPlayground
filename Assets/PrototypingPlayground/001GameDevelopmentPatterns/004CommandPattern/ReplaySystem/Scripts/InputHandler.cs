using PrototypingPlayground._001GameDevelopmentPatterns._004CommandPattern.ReplaySystem.Commands;
using UnityEngine;
using UnityEngine.InputSystem;
namespace PrototypingPlayground._001GameDevelopmentPatterns._004CommandPattern.ReplaySystem
{
    public class InputHandler : MonoBehaviour
    {
        private bool isRecording, isReplaying;
        private Invoker invoker;
        private BikeController bikeController;
        private Command buttonLeft, buttonRight, buttonTurbo;
        private bool buttonLeftPressed, buttonRightPressed, buttonTurboHeld;
        [SerializeField] private GameObject playerTrailRenderer;
        [SerializeField] private GameObject playerCamera;
        private Transform cameraStartPoint;

        private void Start()
        {
            invoker = gameObject.AddComponent<Invoker>();
            bikeController = FindObjectOfType<BikeController>();

            buttonLeft = new TurnLeft(bikeController);
            buttonRight = new TurnRight(bikeController);
            buttonTurbo = new ToggleTurbo(bikeController);
        }

        private void FixedUpdate()
        {
            if(isRecording && !isReplaying)
            {
                if (buttonLeftPressed)
                {
                    invoker.ExecuteCommand(buttonLeft);
                    buttonLeftPressed = false;
                }
                if (buttonRightPressed)
                {
                    invoker.ExecuteCommand(buttonRight);
                    buttonRightPressed = false;
                }
                if (buttonTurboHeld)
                {
                    invoker.ExecuteCommand(buttonTurbo);
                    buttonTurboHeld = false;
                }
            }
        }

        public void OnLeftButtonPressed(InputAction.CallbackContext context)
        {
            buttonLeftPressed = context.action.triggered;
        }
        
        public void OnRightButtonPressed(InputAction.CallbackContext context)
        {
            buttonRightPressed = context.action.triggered;
        }
        
        public void OnTurboButtonHeld(InputAction.CallbackContext context)
        {
            if(context.started)
                buttonTurboHeld = true;
            if(context.canceled)
                buttonTurboHeld = true;
        }
        
        void OnGUI()
        {
            if (GUILayout.Button("Start Recording"))
            {
                bikeController.ResetPosition();
                isReplaying = false;
                isRecording = true;
                invoker.Record();
                playerTrailRenderer.SetActive(true);
                cameraStartPoint = playerCamera.transform;
                bikeController.TurnOffTurbo();
            }

            if (GUILayout.Button("Stop Recording"))
            {
                bikeController.ResetPosition();
                isRecording = false;
                playerTrailRenderer.SetActive(false);
                playerCamera.transform.position = cameraStartPoint.position;
                playerCamera.transform.rotation = cameraStartPoint.rotation;
                bikeController.TurnOffTurbo();
            }

            if (!isRecording)
            {
                if (GUILayout.Button("Start Replay"))
                {
                    bikeController.ResetPosition();
                    isRecording = false;
                    isReplaying = true;
                    invoker.Replay();
                    playerTrailRenderer.SetActive(true);
                    cameraStartPoint = playerCamera.transform;
                    bikeController.TurnOffTurbo();
                }
            }
        }
    }
}

