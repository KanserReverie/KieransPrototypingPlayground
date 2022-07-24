using PrototypingPlayground.UsefulScripts;
using UnityEngine;
using UnityEngine.InputSystem;
namespace PrototypingPlayground.DumplingTesting.DeathAndRespawning
{
    public class DumplingController : MonoBehaviour
    {
        private Rigidbody dumplingRigidBody;
        private Vector2 horizontalMoveInput;
        [SerializeField] private float horizontalMovementInput = 800f;
        
        // Start is called before the first frame update
        void Start()
        {
            dumplingRigidBody = GetComponent<Rigidbody>();
            dumplingRigidBody.freezeRotation = true;
            Respawn();
        }

        private void FixedUpdate()
        {
            dumplingRigidBody.AddForce(new Vector3(horizontalMoveInput.x, 0, horizontalMoveInput.y) * horizontalMovementInput * Time.fixedDeltaTime);
        }

        public void OnMove(InputAction.CallbackContext _moveInput)
        {
            horizontalMoveInput = _moveInput.ReadValue<Vector2>().normalized;
        }

        public void Die()
        {
            if (LivesManager.Instance.AreThereAnyLivesLeft())
            {
                Respawn();
                LivesManager.Instance.LoseLive();
            }
            else
            {
                Debug.Log("Game Over");
                CommonlyUsedStaticMethods.QuitGame();
            }
        }
        
        private void Respawn()
        {
            dumplingRigidBody.velocity = Vector3.zero;
            dumplingRigidBody.angularVelocity = Vector3.zero;
            gameObject.SetActive(false);
            SpawnPoint spawnPoint = (SpawnPoint)FindObjectOfType(typeof(SpawnPoint));
            gameObject.transform.position = spawnPoint.SpawnPointTransform.position;
            gameObject.transform.rotation = spawnPoint.SpawnPointTransform.rotation;
            gameObject.SetActive(true);
        }
    }
}
