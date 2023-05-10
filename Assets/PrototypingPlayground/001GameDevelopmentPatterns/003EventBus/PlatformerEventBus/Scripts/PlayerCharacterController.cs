using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._003EventBus.PlatformerEventBus
{
    public class PlayerCharacterController : MonoBehaviour
    {
        private CharacterController characterController;
        [Header("Physics Settings")]
        [SerializeField] private float playerMoveSpeed = 5f;
        [SerializeField] private float playerGravity = 9.81f;
        [SerializeField] private float playerJumpStrength = 6;
        [SerializeField] private float playerMaxVelocity = 10;
        [SerializeField] private float playerFallDelay = 0.2f;
        private float currentPlayerFallDelay = 0.2f;
        [Header("Respawn")]
        [SerializeField] private Vector3 playerRespawnPointPosition;
        [SerializeField] private Quaternion playerRespawnPointRotation;
        private bool canThePlayerMove;
        private Vector3 playerMovement = Vector3.zero;
        private GameManagerEventBus gameManagerEventBus;

        #region Subscribe and Unsubscribe to Event Bus at OnEnable/OnDisable
        
        private void OnEnable()
        {
            gameManagerEventBus = GameManagerEventBus.FindEventBusInScene();
            gameManagerEventBus.SubscribeActionToEvent(TurnOnPlayerMovement,PlatformerEvents.Start);
            gameManagerEventBus.SubscribeActionToEvent(RespawnPlayer,PlatformerEvents.Die);
        }

        private void OnDisable()
        {
            gameManagerEventBus.UnsubscribeActionFromEvent(TurnOnPlayerMovement, PlatformerEvents.Start);
            gameManagerEventBus.UnsubscribeActionFromEvent(RespawnPlayer,PlatformerEvents.Die);
        }
        
        #endregion

        private void Start()
        {
            currentPlayerFallDelay = 0;
            playerRespawnPointPosition = transform.position;
            playerRespawnPointRotation = transform.rotation;
            canThePlayerMove = false;
            
            gameManagerEventBus = GameManagerEventBus.FindEventBusInScene();

            if(gameManagerEventBus != null)
                gameManagerEventBus.SubscribeActionToEvent(TurnOnPlayerMovement,PlatformerEvents.Start);
            
            characterController = GetComponent<CharacterController>();
            if (characterController == null)
            {
                Debug.LogWarning("Please attach a Character Controller, adding a default one");
                gameObject.AddComponent<CharacterController>();
            }
        }

        private void TurnOnPlayerMovement()
        {
            canThePlayerMove = true;
        }
        
        private void Update()
        {
            if (canThePlayerMove)
            {
                playerMovement.x = 0;
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    playerMovement.x -= playerMoveSpeed * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    playerMovement.x += playerMoveSpeed * Time.deltaTime;
                }
                if (characterController.isGrounded || currentPlayerFallDelay > 0)
                {
                    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
                    {
                        playerMovement.y = playerJumpStrength;
                        currentPlayerFallDelay = 0;
                    }
                }
            }
            characterController.Move(playerMovement);
            
            if (!characterController.isGrounded)
            {
                if (currentPlayerFallDelay > 0)
                {
                    print(currentPlayerFallDelay);
                    currentPlayerFallDelay -= Time.deltaTime;
                }
                else
                { 
                    if (playerMovement.y < -playerMaxVelocity)
                        playerMovement.y = -playerMaxVelocity;
                    else
                        playerMovement.y -= playerGravity * Time.deltaTime;
                }
            }
            else
            {
                playerMovement.y = -0.01f;
                currentPlayerFallDelay = playerFallDelay;
            }
        }
        
        private void OnControllerColliderHit(ControllerColliderHit other)
        {
            if (other.gameObject.CompareTag("Obstacle"))
            {
                gameManagerEventBus.PublishEvent(PlatformerEvents.Die);
                Destroy(other.gameObject); 
            }
        }
        
        private void RespawnPlayer()
        {
            characterController.enabled = false;
            characterController.transform.position = playerRespawnPointPosition;
            characterController.transform.rotation = playerRespawnPointRotation;
            characterController.enabled = true;
        }
    }
}
