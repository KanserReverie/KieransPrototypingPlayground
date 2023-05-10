using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._003EventBus.GenericEventBus
{
    /// <summary>
    /// A simple player death boundary:
    /// 1) This Publishes Event3 when a "Player" (determined by tags) touches it.
    ///
    /// In this case "Event3" would probably be an event like "PlayerDeath".
    ///
    /// In this case we dont need to Subscribe or Unsubscribe only Publish an event.
    /// </summary>
    public class SimpleExample2PlayerDeath : MonoBehaviour
    {
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.CompareTag($"Player"))
            {
                StaticEventBusManager.Publish(EventBusEvent.Event3);
            }
        }
    }
}
