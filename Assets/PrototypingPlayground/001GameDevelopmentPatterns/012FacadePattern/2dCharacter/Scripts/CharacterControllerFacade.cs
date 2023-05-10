using PrototypingPlayground._001GameDevelopmentPatterns._012FacadePattern._2dCharacter.CharacterController;
using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._012FacadePattern._2dCharacter
{
    /// <summary>
    /// This will hold all the functions for a simple character controller.
    /// </summary>
    public class CharacterControllerFacade : MonoBehaviour
    {
        [Header("Character Respawn")]
        [SerializeField] private Vector3 spawnPoint = Vector3.zero;
        
        [Header("Character Health")]
        [SerializeField] private float startingHealth = 100;
        
        [Header("Character Movement")]
        [SerializeField] private float walkSpeed = 5;
        [SerializeField] private float jumpForce = 8;

        private MovementSystem playerMovement;
        private HealthSystem playerHealth;
        private RespawnSystem playerRespawn;
        private PlayerRenderSystem playerRenderSystem;
        private PlayerColliderSystem playerColliderSystem;

        public bool IsPlayerAlive => playerHealth.IsPlayerAlive;

        private void Awake()
        {
            playerMovement = gameObject.AddComponent<MovementSystem>();
            playerHealth = gameObject.AddComponent<HealthSystem>();
            playerRespawn = gameObject.AddComponent<RespawnSystem>();
            playerRenderSystem = gameObject.AddComponent<PlayerRenderSystem>();
            playerColliderSystem = gameObject.AddComponent<PlayerColliderSystem>();
        }

        public void SpawnPlayer()
        {
            spawnPoint = playerRespawn.GetSpawnLocation();
            playerMovement.MovePlayerToSpawn(spawnPoint);
            playerColliderSystem.TurnOnPlayerColliders();
            playerMovement.EnablePlayerMovement();
            playerHealth.SpawnPlayer(startingHealth);
            playerRenderSystem.TurnOnPlayerRenders();
            Debug.Log("Spawning");
        }
        
        public void RespawnPlayer()
        {
            spawnPoint = playerRespawn.GetSpawnLocation();
            playerMovement.MovePlayerToSpawn(spawnPoint);
            playerColliderSystem.TurnOnPlayerColliders();
            playerMovement.EnablePlayerMovement();
            playerHealth.SpawnPlayer(startingHealth);
            playerRenderSystem.TurnOnPlayerRenders();
            Debug.Log("Respawning");
        }

        public void Move(Vector2 moveInput)
        {
            playerMovement.Walk(moveInput.x, walkSpeed);
        }
        public void Jump()
        {
            playerMovement.Jump(jumpForce);
        }
        public void Die()
        {
            playerHealth.KillPlayer();
            playerRenderSystem.TurnOffPlayerRenders();
            playerMovement.DisablePlayerMovement();
            playerColliderSystem.TurnOffPlayerColliders();
            Debug.Log("You Died");
        }
    }
}
