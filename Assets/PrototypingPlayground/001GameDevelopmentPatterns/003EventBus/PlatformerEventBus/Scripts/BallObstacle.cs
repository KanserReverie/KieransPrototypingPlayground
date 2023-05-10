using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._003EventBus.PlatformerEventBus
{
    public class BallObstacle : MonoBehaviour
    {
        private void OnCollisionStay(Collision other)
        {
            if (other.gameObject.CompareTag($"Player"))
            {
                Debug.Log("Die");
                GameManagerEventBus.FindEventBusInScene().PublishEvent(PlatformerEvents.Die);
            }
            Destroy(this);
        }
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag($"Player"))
            {
                Debug.Log("Die");
                GameManagerEventBus.FindEventBusInScene().PublishEvent(PlatformerEvents.Die);
            }
            Destroy(this);
        }
    }
}
