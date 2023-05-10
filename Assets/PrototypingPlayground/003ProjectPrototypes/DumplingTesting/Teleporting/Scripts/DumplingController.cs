using PrototypingPlayground._003ProjectPrototypes.DumplingTesting.Teleporting.ActivateCommands;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
namespace PrototypingPlayground._003ProjectPrototypes.DumplingTesting.Teleporting
{
    public class DumplingController : MonoBehaviour
    {
        [SerializeField] private float horizontalMovementSpeed;
        [SerializeField] private GameObject activateText;
        private Rigidbody dumplingRigidbody;
        private Vector2 horizontalMoveInput;
        private UnityAction activateAction;
        
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
