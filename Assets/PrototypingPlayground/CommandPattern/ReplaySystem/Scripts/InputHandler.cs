using UnityEngine;
using UnityEngine.InputSystem;
using PrototypingPlayground.CommandPattern.ReplaySystem.Commands;

namespace PrototypingPlayground.CommandPattern.ReplaySystem
{
    public class InputHandler : MonoBehaviour
    {
        private bool _isRecording, _isReplaying;
        private Invoker _invoker;
        private BikeController _bikeController;
        private Command _buttonLeft, _buttonRight, _buttonTurbo;
        private bool _buttonLeftPressed, _buttonRightPressed, _buttonTurboHeld;
        [SerializeField] private GameObject playerTrailRenderer;
        [SerializeField] private GameObject playerCamera;
        private Transform _cameraStartPoint;

        private void Start()
        {
            _invoker = gameObject.AddComponent<Invoker>();
            _bikeController = FindObjectOfType<BikeController>();

            _buttonLeft = new TurnLeft(_bikeController);
            _buttonRight = new TurnRight(_bikeController);
            _buttonTurbo = new ToggleTurbo(_bikeController);
        }

        private void FixedUpdate()
        {
            if(_isRecording && !_isReplaying)
            {
                if (_buttonLeftPressed)
                {
                    _invoker.ExecuteCommand(_buttonLeft);
                    _buttonLeftPressed = false;
                }
                if (_buttonRightPressed)
                {
                    _invoker.ExecuteCommand(_buttonRight);
                    _buttonRightPressed = false;
                }
                if (_buttonTurboHeld)
                {
                    _invoker.ExecuteCommand(_buttonTurbo);
                    _buttonTurboHeld = false;
                }
            }
        }

        public void OnLeftButtonPressed(InputAction.CallbackContext context)
        {
            _buttonLeftPressed = context.action.triggered;
        }
        
        public void OnRightButtonPressed(InputAction.CallbackContext context)
        {
            _buttonRightPressed = context.action.triggered;
        }
        
        public void OnTurboButtonHeld(InputAction.CallbackContext context)
        {
            if(context.started)
                _buttonTurboHeld = true;
            if(context.canceled)
                _buttonTurboHeld = true;
        }
        
        void OnGUI()
        {
            if (GUILayout.Button("Start Recording"))
            {
                _bikeController.ResetPosition();
                _isReplaying = false;
                _isRecording = true;
                _invoker.Record();
                playerTrailRenderer.SetActive(true);
                _cameraStartPoint = playerCamera.transform;
                _bikeController.TurnOffTurbo();
            }

            if (GUILayout.Button("Stop Recording"))
            {
                _bikeController.ResetPosition();
                _isRecording = false;
                playerTrailRenderer.SetActive(false);
                playerCamera.transform.position = _cameraStartPoint.position;
                playerCamera.transform.rotation = _cameraStartPoint.rotation;
                _bikeController.TurnOffTurbo();
            }

            if (!_isRecording)
            {
                if (GUILayout.Button("Start Replay"))
                {
                    _bikeController.ResetPosition();
                    _isRecording = false;
                    _isReplaying = true;
                    _invoker.Replay();
                    playerTrailRenderer.SetActive(true);
                    _cameraStartPoint = playerCamera.transform;
                    _bikeController.TurnOffTurbo();
                }
            }
        }
    }
}

