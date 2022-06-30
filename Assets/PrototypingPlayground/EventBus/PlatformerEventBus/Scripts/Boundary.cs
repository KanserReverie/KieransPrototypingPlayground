using System;
using UnityEngine;
namespace PrototypingPlayground.EventBus.PlatformerEventBus
{
    public class Boundary : MonoBehaviour
    {
        private GameManagerEventBus _gameManagerEventBus;

        private void Start()
        {
            _gameManagerEventBus = GameManagerEventBus.FindEventBusInScene();
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag($"Player"))
            {
                _gameManagerEventBus.PublishEvent(PlatformerEvents.DIE);
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
                _gameManagerEventBus.PublishEvent(PlatformerEvents.DIE);
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
    }
}
