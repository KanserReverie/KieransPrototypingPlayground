using System;
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
        [SerializeField] private float currentHealth;
        [SerializeField] private float startingHealth = 100;
        [SerializeField] private float healthRegenPerSecond = 1;
        
        [Header("Character Movement")]
        [SerializeField] private float walkSpeed = 4;
        [SerializeField] private float jumpForce = 10;

        private MovementSystem playerMovement;
        private HealthSystem playerHealth;
        private RespawnSystem playerRespawn;
        
        private void Awake()
        {
            playerMovement = gameObject.AddComponent<MovementSystem>();
            playerHealth = gameObject.AddComponent<HealthSystem>();
            playerRespawn = gameObject.AddComponent<RespawnSystem>();
        }

        public void SpawnPlayer()
        {
            currentHealth = startingHealth;
            Vector3 spawnLocation = RespawnSystem.GetSpawnLocation();
            playerMovement.MovePlayerToSpawn(spawnLocation);
        }

    }
}
