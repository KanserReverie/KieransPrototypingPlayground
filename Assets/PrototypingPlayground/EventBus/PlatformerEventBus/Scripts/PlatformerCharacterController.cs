using System;
using Unity.VisualScripting;
using UnityEngine;
namespace PrototypingPlayground.EventBus.PlatformerEventBus
{
    public class PlatformerCharacterController : MonoBehaviour
    {
        private CharacterController _characterController;
        [SerializeField] private float playerMoveSpeed = 5f;
        [SerializeField] private float playerGravity = 9.81f;
        [SerializeField] private float playerJumpStrength = 6;
        [SerializeField] private float playerMaxVelocity = 10;
        [SerializeField] private Vector3 playerRespawnPoint = Vector3.zero;
        private bool _canThePlayerMove;
        private Vector3 _playerMovement = Vector3.zero;

        private PlatformerGameManagerEventBus _platformerGameManagerEventBus;


        #region Subscribe and Unsubscribe to Event Bus at OnEnable/OnDisable
        
        private void OnEnable()
        {
            _platformerGameManagerEventBus = PlatformerGameManagerEventBus.FindEventBusInScene();
            _platformerGameManagerEventBus.SubscribeActionToEvent(TurnOnPlayerMovement,PlatformerEvents.START);
            _platformerGameManagerEventBus.SubscribeActionToEvent(RespawnPlayer,PlatformerEvents.DIE);
        }

        private void OnDisable()
        {
            _platformerGameManagerEventBus.UnsubscribeActionFromEvent(TurnOnPlayerMovement, PlatformerEvents.START);
            _platformerGameManagerEventBus.UnsubscribeActionFromEvent(RespawnPlayer,PlatformerEvents.DIE);
        }
        
        #endregion

        private void Start()
        {
            playerRespawnPoint = transform.position;
            
            _canThePlayerMove = false;
            
            _platformerGameManagerEventBus = PlatformerGameManagerEventBus.FindEventBusInScene();

            if(_platformerGameManagerEventBus != null)
                _platformerGameManagerEventBus.SubscribeActionToEvent(TurnOnPlayerMovement,PlatformerEvents.START);
            
            _characterController = GetComponent<CharacterController>();
            if (_characterController == null)
            {
                Debug.LogWarning("Please attach a Character Controller, adding a default one");
                this.gameObject.AddComponent<CharacterController>();
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
                if (_characterController.isGrounded)
                {
                    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
                    {
                        _playerMovement.y = playerJumpStrength;
                    }
                }
            }
            _characterController.Move(_playerMovement);
            if (_playerMovement.y > playerMaxVelocity)
                _playerMovement.y = playerMaxVelocity;
            else
                _playerMovement.y -= playerGravity * Time.deltaTime;
        }

        private void RespawnPlayer()
        {
            transform.position = playerRespawnPoint;
        }
    }
}
