using System;
using PrototypingPlayground.UsefulScripts;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace PrototypingPlayground.BasicConcepts.Assertions
{
    public class PlayerSphereController : MonoBehaviour
    {
        [SerializeField] private AudioClip sfxSpawn;
        [SerializeField] private AudioClip sfxDie;
        [SerializeField] private float playerSpeed;
        private Vector2 horizontalInput;
        private Rigidbody playerRigidbody;
        private bool playerDead;

        private void Awake()
        {
            Assert.IsNotNull(sfxSpawn);
            Assert.IsNotNull(sfxDie);
            Assert.IsTrue(playerSpeed > 0);
            playerRigidbody = GetComponent<Rigidbody>();
            playerDead = false;
        }

        private void Start()
        {
            AudioSource.PlayClipAtPoint(sfxSpawn, transform.position);
        }

        private void Update()
        {
            if (playerDead)
                return;
            if (transform.position.y < -800f)
            {
                Debug.Log("Good bye");
                AudioSource.PlayClipAtPoint(sfxDie, transform.position);
                //sfxDie
                Invoke(nameof(QuitGame), 3f);
                playerDead = true;
            }
        }
        
        private void QuitGame()
        {
            CommonlyUsedStaticMethods.QuitGame();
        }
        private void FixedUpdate()
        {
            if (playerDead)
                return;
            Vector3 desiredAcceleration = new Vector3(horizontalInput.x, 0, horizontalInput.y) * playerRigidbody.mass * playerSpeed;
            Assert.IsTrue(horizontalInput.magnitude == 0 || desiredAcceleration.magnitude > 0 );
            playerRigidbody.AddForce(desiredAcceleration);
            Assert.IsTrue(playerRigidbody.velocity.magnitude < 100); // Velocity is done in meters a second.
        }

        public void OnMove(InputAction.CallbackContext _movementInput)
        {
            horizontalInput = _movementInput.ReadValue<Vector2>();
            // Checking if normalized
            Assert.IsFalse(horizontalInput.magnitude > 1);
        }
    }
}
