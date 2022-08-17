using UnityEngine;
using UnityEngine.InputSystem;
namespace PrototypingPlayground._4.QuickPrototypes.ControllerMainMenu.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private GameObject mainMenu;

        public void OnPause(InputAction.CallbackContext _inputPressed)
        {
            if (_inputPressed.performed && Time.timeScale != 0)
            {
                mainMenu.gameObject.SetActive(true);
            }
        }
}
}
