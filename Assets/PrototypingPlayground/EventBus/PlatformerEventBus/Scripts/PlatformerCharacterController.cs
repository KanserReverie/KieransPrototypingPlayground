using Unity.VisualScripting;
using UnityEngine;
namespace PrototypingPlayground.EventBus.PlatformerEventBus
{
    public class PlatformerCharacterController : MonoBehaviour
    {
        private CharacterController _characterController;
        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
            if (_characterController == null)
            {
                Debug.LogWarning("Please attach a Character Controller, adding a default one");
                this.gameObject.AddComponent<CharacterController>();
            }
        }
    }
}
