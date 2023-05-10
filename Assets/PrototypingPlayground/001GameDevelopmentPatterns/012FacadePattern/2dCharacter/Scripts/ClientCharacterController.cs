using UnityEngine;
using UnityEngine.InputSystem;
// ReSharper disable All

namespace PrototypingPlayground._001GameDevelopmentPatterns._012FacadePattern._2dCharacter
{
    [RequireComponent(typeof(CharacterControllerFacade))]
    public class ClientCharacterController : MonoBehaviour
    {
        private CharacterControllerFacade characterControllerFacade;
        
        private void Start()
        {
            characterControllerFacade = GetComponent<CharacterControllerFacade>();
            if (characterControllerFacade == null)
            {
                characterControllerFacade = gameObject.AddComponent<CharacterControllerFacade>();
            }
            characterControllerFacade.SpawnPlayer();
        }

        private void Update()
        {
            if (transform.position.y <= -2 && characterControllerFacade.IsPlayerAlive)
            {
                characterControllerFacade.Die();
            }
        }

        public void OnRespawn(InputAction.CallbackContext _respawnInput)
        {
            if(_respawnInput.performed)
            {
                characterControllerFacade.RespawnPlayer();
            }
        }
        
        public void OnMove(InputAction.CallbackContext _horizontalInput)
        {
            characterControllerFacade.Move(_horizontalInput.ReadValue<Vector2>());
        }
        
        public void OnJump(InputAction.CallbackContext _moveInput)
        {
            if(_moveInput.performed)
            {
                characterControllerFacade.Jump();
            }
        }
        
        private void OnGUI()
        {
            if (!characterControllerFacade.IsPlayerAlive)
            {
                if (Time.time % 2 < 1)
                {
                    if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 200, 30), "Press R to Respawn"))
                    {
                        characterControllerFacade.RespawnPlayer();
                    }
                }
            }
        }
    }
}
