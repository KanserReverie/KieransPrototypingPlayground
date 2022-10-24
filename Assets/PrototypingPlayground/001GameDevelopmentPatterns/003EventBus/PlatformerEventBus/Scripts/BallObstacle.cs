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
                GameManagerEventBus.FindEventBusInScene().PublishEvent(PlatformerEvents.DIE);
            }
            Destroy(this);
        }
        private void OnCollisionHit(Collision other)
        {
            if (other.gameObject.CompareTag($"Player"))
            {
                Debug.Log("Die");
                GameManagerEventBus.FindEventBusInScene().PublishEvent(PlatformerEvents.DIE);
            }
            Destroy(this);
        }
    }
}
