using UnityEngine;
namespace PrototypingPlayground._1.GameDevelopmentPatterns._3.EventBus.PlatformerEventBus
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
