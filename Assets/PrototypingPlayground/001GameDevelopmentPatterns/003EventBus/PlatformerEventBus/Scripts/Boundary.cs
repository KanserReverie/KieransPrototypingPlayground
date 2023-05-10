using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._003EventBus.PlatformerEventBus
{
    public class Boundary : MonoBehaviour
    {
        private GameManagerEventBus gameManagerEventBus;

        private void Start()
        {
            gameManagerEventBus = GameManagerEventBus.FindEventBusInScene();
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag($"Player"))
            {
                gameManagerEventBus.PublishEvent(PlatformerEvents.Die);
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag($"Player"))
            {
                gameManagerEventBus.PublishEvent(PlatformerEvents.Die);
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
    }
}
