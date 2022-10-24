using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._003EventBus.PlatformerEventBus
{
    public class PlayerCharacterController : MonoBehaviour
    {
        private UnityEngine.CharacterController _characterController;
        [Header("Physics Settings")]
        [SerializeField] private float playerMoveSpeed = 5f;
        [SerializeField] private float playerGravity = 9.81f;
        [SerializeField] private float playerJumpStrength = 6;
        [SerializeField] private float playerMaxVelocity = 10;
        [SerializeField] private float playerFallDelay = 0.2f;
        private float _currentPlayerFallDelay = 0.2f;
        [Header("Respawn")]
        [SerializeField] private Vector3 playerRespawnPointPosition;
        [SerializeField] private Quaternion playerRespawnPointRotation;
        private bool _canThePlayerMove;
        private Vector3 _playerMovement = Vector3.zero;
        private GameManagerEventBus _gameManagerEventBus;

        #region Subscribe and Unsubscribe to Event Bus at OnEnable/OnDisable
        
        private void OnEnable()
        {
            _gameManagerEventBus = GameManagerEventBus.FindEventBusInScene();
            _gameManagerEventBus.SubscribeActionToEvent(TurnOnPlayerMovement,PlatformerEvents.START);
            _gameManagerEventBus.SubscribeActionToEvent(RespawnPlayer,PlatformerEvents.DIE);
        }

        private void OnDisable()
        {
            _gameManagerEventBus.UnsubscribeActionFromEvent(TurnOnPlayerMovement, PlatformerEvents.START);
            _gameManagerEventBus.UnsubscribeActionFromEvent(RespawnPlayer,PlatformerEvents.DIE);
        }
        
        #endregion

        private void Start()
        {
            _currentPlayerFallDelay = 0;
            playerRespawnPointPosition = transform.position;
            playerRespawnPointRotation = transform.rotation;
            _canThePlayerMove = false;
            
            _gameManagerEventBus = GameManagerEventBus.FindEventBusInScene();

            if(_gameManagerEventBus != null)
                _gameManagerEventBus.SubscribeActionToEvent(TurnOnPlayerMovement,PlatformerEvents.START);
            
            _characterController = GetComponent<UnityEngine.CharacterController>();
            if (_characterController == null)
            {
                Debug.LogWarning("Please attach a Character Controller, adding a default one");
                this.gameObject.AddComponent<UnityEngine.CharacterController>();
            }
        }

        private void TurnOnPlayerMovement()
        {
            _canThePlayerMove = true;
        }
        
        private void Update()
        {
            if (_canThePlayerMove)
            {
                _playerMovement.x = 0;
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    _playerMovement.x -= playerMoveSpeed * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    _playerMovement.x += playerMoveSpeed * Time.deltaTime;
                }
                if (_characterController.isGrounded || _currentPlayerFallDelay > 0)
                {
                    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
                    {
                        _playerMovement.y = playerJumpStrength;
                        _currentPlayerFallDelay = 0;
                    }
                }
            }
            _characterController.Move(_playerMovement);
            
            if (!_characterController.isGrounded)
            {
                if (_currentPlayerFallDelay > 0)
                {
                    print(_currentPlayerFallDelay);
                    _currentPlayerFallDelay -= Time.deltaTime;
                }
                else
                { 
                    if (_playerMovement.y < -playerMaxVelocity)
                        _playerMovement.y = -playerMaxVelocity;
                    else
                        _playerMovement.y -= playerGravity * Time.deltaTime;
                }
            }
            else
            {
                _playerMovement.y = -0.01f;
                _currentPlayerFallDelay = playerFallDelay;
            }
        }
        
        private void OnControllerColliderHit(ControllerColliderHit other)
        {
            if (other.gameObject.CompareTag("Obstacle"))
            {
                _gameManagerEventBus.PublishEvent(PlatformerEvents.DIE);
                Destroy(other.gameObject); 
            }
        }
        
        private void RespawnPlayer()
        {
            _characterController.enabled = false;
            _characterController.transform.position = playerRespawnPointPosition;
            _characterController.transform.rotation = playerRespawnPointRotation;
            _characterController.enabled = true;
        }
    }
}
