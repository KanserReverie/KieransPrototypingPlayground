using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._004CommandPattern.MarbleReplaySystem
{
    public class MarbleController : MonoBehaviour
    {
        private Rigidbody playerRigidbody;
        [SerializeField] private float jumpForce = 300f;
        [SerializeField] private float movementSpeed = 4f;
        [SerializeField] private float playerGravity = 9.81f;
        private Vector3 spawnPoint;
        private Quaternion spawnRotation;
        
        public void Init(float jumpForce, float movementSpeed, float playerGravity)
        {
            this.jumpForce = jumpForce;
            this.movementSpeed = movementSpeed;
            this.playerGravity = playerGravity;
        }
        public void Start()
        {
            playerRigidbody = GetComponent<Rigidbody>();
            spawnPoint = transform.position;
            spawnRotation = transform.rotation;
        }

        public void FixedUpdate()
        {
            // Add extra gravity.
            Vector3 gravityForce = new(0, -playerGravity, 0);
            gravityForce -= Physics.gravity;
            playerRigidbody.AddForce(gravityForce);
        }
        public void Jump()
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce);
        }
        public void HorizontalMovement(Vector2 movementInput)
        {
            movementInput.Normalize();
            Vector3 movementForce = Vector3.forward;
            movementForce.x += movementInput.x;
            movementForce.z += movementInput.y;
            playerRigidbody.AddForce(new Vector3(movementInput.x,0,movementInput.y)*movementSpeed);
        }

        public void SpawnMarble()
        {
            transform.position = spawnPoint;
            transform.rotation = spawnRotation;
            playerRigidbody.velocity = new Vector3(0,0,0);
            playerRigidbody.angularVelocity = new Vector3(0f,0f,0f);
        }
    }
}
