using System;
using UnityEngine;
namespace PrototypingPlayground.EventBus.PlatformerEventBus
{
    public class Boundary : MonoBehaviour
    {
        private Collider _boundaryCollider;
        private PlatformerGameManagerEventBus _platformerGameManagerEventBus;

        private void Start()
        {
            _boundaryCollider = GetComponent<Collider>();
            
            _platformerGameManagerEventBus = PlatformerGameManagerEventBus.FindEventBusInScene();
        }

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            Debug.Log("hit");
            if (hit.gameObject.CompareTag($"Player"));
            {
                _platformerGameManagerEventBus.PublishEvent(PlatformerEvents.DIE);
            }
        }
    }
}
