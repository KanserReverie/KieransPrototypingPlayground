using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
namespace PrototypingPlayground.VRandSplitScreenLocalGame
{
    [RequireComponent(typeof(Rigidbody))]
    public class SmallPlayerController : MonoBehaviour
    {
        private Rigidbody smallPlayerRigidbody;
        [SerializeField, ReadOnly]private Vector2 horizontalMovementInput;
        // Start is called before the first frame update
        void Start()
        {
            smallPlayerRigidbody = GetComponent<Rigidbody>();
        }

        private void OnMove(InputAction.CallbackContext _movementInput)
        {
            
        }
    }
}
