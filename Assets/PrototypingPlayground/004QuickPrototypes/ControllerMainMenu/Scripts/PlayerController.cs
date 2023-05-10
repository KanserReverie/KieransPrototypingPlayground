using UnityEngine;
using UnityEngine.InputSystem;
namespace PrototypingPlayground._004QuickPrototypes.ControllerMainMenu
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private GameObject mainMenu;

        public void OnPause(InputAction.CallbackContext inputPressed)
        {
            if (inputPressed.performed && Time.timeScale != 0)
            {
                mainMenu.gameObject.SetActive(true);
            }
        }
    }
}
