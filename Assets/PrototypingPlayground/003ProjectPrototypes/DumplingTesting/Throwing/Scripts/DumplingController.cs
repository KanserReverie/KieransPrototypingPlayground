using PrototypingPlayground._003ProjectPrototypes.DumplingTesting.Throwing.ActivateCommands;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
namespace PrototypingPlayground._003ProjectPrototypes.DumplingTesting.Throwing
{
    public class DumplingController : MonoBehaviour
    {
        private Rigidbody dumplingRigidbody;
        private Vector2 horizontalMoveInput;
        private UnityAction activateAction;
        [SerializeField] private float horizontalMovementSpeed = 5f;
        [SerializeField] private GameObject activateText;

        // Start is called before the first frame update
        void Start()
        {
            dumplingRigidbody = GetComponent<Rigidbody>();
            dumplingRigidbody.freezeRotation = true;
            activateText.SetActive(false);
        }

        private void FixedUpdate()
        {
            dumplingRigidbody.AddForce(new Vector3(horizontalMoveInput.x, 0, horizontalMoveInput.y) * horizontalMovementSpeed);
        }

        public void OnMove(InputAction.CallbackContext moveInput)
        {
            horizontalMoveInput = moveInput.ReadValue<Vector2>().normalized;
        }

        public void OnActivate(InputAction.CallbackContext activate)
        {
            if (activate.started)
            {
                activateAction?.Invoke();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            AbstractActivatePoint activePoint = other.gameObject.GetComponent<AbstractActivatePoint>();
            
            if (activePoint != null)
            {
                AbstractActivateCommands activeCommand;
                activeCommand = activePoint.GetActivePointCommand(dumplingRigidbody);
                activateAction += activeCommand.ExecuteCommand;
                activateText.SetActive(true);
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            AbstractActivatePoint activePoint = other.gameObject.GetComponent<AbstractActivatePoint>();
            
            if (activePoint != null)
            {
                activateAction = null;
                activateText.SetActive(false);
            }
        }
    }
}
