using UnityEngine;
using UnityEngine.InputSystem;
// ReSharper disable All
namespace PrototypingPlayground._001GameDevelopmentPatterns._007VisitorPattern.BasicPlatformer
{
    public class BasicPlatformerRigidbodyCharacterController : MonoBehaviour
    {
        [Header("Rigidbody")]
        [SerializeField] private bool freezeRotation;
        [SerializeField] private bool freezeZAxis;
        [SerializeField]
        private new Rigidbody rigidbody;
        private bool usingAbility;
        private bool jumping;
        private Vector3 movementInput = Vector3.zero;

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

        public void Jump(InputAction.CallbackContext jumpInput)
        {
            jumping = jumpInput.performed;
        }

        public void Move(InputAction.CallbackContext moveInput)
        {
            movementInput.x = moveInput.ReadValue<float>();
            Debug.Log($"Move Input = {movementInput}");
        }

        public void UseAbility(InputAction.CallbackContext useAbilityInput)
        {
            usingAbility = useAbilityInput.ReadValue<float>() > 0.1f;
        }
    }
}
