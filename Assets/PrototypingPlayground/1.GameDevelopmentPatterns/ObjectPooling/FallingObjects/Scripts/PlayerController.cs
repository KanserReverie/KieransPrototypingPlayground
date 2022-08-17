using PrototypingPlayground.UsefulScripts;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;
namespace PrototypingPlayground._1.GameDevelopmentPatterns.ObjectPooling.FallingObjects.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody playerRigidbody;
        [Header("Movement")]
        [SerializeField] private float horizontalSpeed = 12f;
        private float horizontalInput;
        [Header("Jumping")]
        [SerializeField] private int extraJumps = 1;
        [SerializeField] private float additionalFallingGravity = 40f;
        [SerializeField] private float jumpVelocity = 11f;
        [SerializeField] private float velocityToApplyExtraGravity = 9.5f;
        private bool isJumping;
        private int currentExtraJumps;
        [Header("Lives")]
        [SerializeField] private int lives = 2;
        [SerializeField] private float deathHeight = -8;
        [SerializeField] private string livesText = "Lives = ";
        [SerializeField] private TMP_Text livesTMPText;
        private int currentLives;
        private Vector3 spawnPoint;
        

        private void Awake()
        {
            playerRigidbody = GetComponentInChildren<Rigidbody>();
            spawnPoint = transform.position;
            currentLives = lives;
            Assert.IsNotNull(livesTMPText);
            Assert.IsTrue(spawnPoint.y > deathHeight);
        }

        private void Update()
        {
            livesTMPText.text = $"{livesText}{currentLives}";
        }
        private void FixedUpdate()
        {
            Vector3 desiredVelocity = new Vector3(0, 0, horizontalInput * horizontalSpeed);
            if (isJumping)
            {
                desiredVelocity += Vector3.up * jumpVelocity;
                isJumping = false;
            }
            else
            {
                if (playerRigidbody.velocity.y < velocityToApplyExtraGravity && !IsGrounded())
                    desiredVelocity += Vector3.up * -additionalFallingGravity * Time.fixedDeltaTime;
                desiredVelocity += Vector3.up * playerRigidbody.velocity.y;
            }
            playerRigidbody.velocity = desiredVelocity;
            
            if (IsGrounded()) currentExtraJumps = extraJumps;

            if (transform.position.y < deathHeight)
            {
                Die();
            }
        }
        private void Die()
        {
            currentLives--;
            if (currentLives > 0)
            {
                Respawn();
            }
            else
            {
                CommonlyUsedStaticMethods.QuitGame();
            }
        }
        private void Respawn()
        {
            transform.position = spawnPoint;
            playerRigidbody.velocity = Vector3.zero;
            playerRigidbody.angularVelocity = Vector3.zero;
        }

        public void OnMove(InputAction.CallbackContext _movementInput)
        {
            horizontalInput = _movementInput.ReadValue<float>();
        }
        
        public void OnJump(InputAction.CallbackContext _jumpInput)
        {
            if (_jumpInput.performed)
            {
                if (IsGrounded())
                {
                    isJumping = true;
                }
                else if (currentExtraJumps > 0 )
                {
                    currentExtraJumps--;
                    isJumping = true;
                }
            }
        }
        private bool IsGrounded() => Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down),1.2f);

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Obstacle"))
            {
                Die();
            }
            if (other.gameObject.CompareTag("Finish"))
            {
                Debug.ClearDeveloperConsole();
                Debug.Log("Congratulations, You Win!!");
                CommonlyUsedStaticMethods.QuitGame();
            }
        }
    }
}
