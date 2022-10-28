using UnityEngine;
using UnityEngine.InputSystem;
namespace PrototypingPlayground._001GameDevelopmentPatterns._007VisitorPattern.BasicPlatformer
{
    public class BasicPlatformerRigidbodyCharacterController : MonoBehaviour
    {
        [Header("Rigidbody")]
        [SerializeField] private bool freezeRotation;
        [SerializeField] private bool freezeZAxis;
        [SerializeField]
        private Vector3 movementInput = Vector3.zero;
        private new Rigidbody rigidbody;
        
        private void Start()
        {
            SetUpRigidBody();
        }

        private void SetUpRigidBody()
        {
            rigidbody = gameObject.AddComponent<Rigidbody>();
            if (freezeRotation)
            {
                rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            }
            if (freezeZAxis)
            {
                rigidbody.constraints = rigidbody.constraints | RigidbodyConstraints.FreezePositionZ;
            }
        }

        public void Jump(InputAction.CallbackContext _jumpInput)
        {
            if (_jumpInput.performed)
            {
                Debug.Log("Jump Performed");
            }
        }

        public void Move(InputAction.CallbackContext _moveInput)
        {
            movementInput.x = _moveInput.ReadValue<float>();
            Debug.Log($"Move Input = {movementInput}");
         }

        public void UseAbility(InputAction.CallbackContext _useAbilityInput)
        {
            if (_useAbilityInput.ReadValue<float>() > 0.1f)
            {
                Debug.Log("Using Ability");
            }
        }
    }
}
