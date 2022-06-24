using System.Collections.Generic;
using UnityEngine.Events;
namespace PrototypingPlayground.EventBus.PlatformerEventBus
{
    public class PlatformerGameManagerEventBus
    {
        private readonly IDictionary<PlatformerEvents, UnityEvent> _platformerEventsToUnityEvents = new Dictionary<PlatformerEvents, UnityEvent>();

        public void SubscribeUnityActionToPlatformerEvent(UnityAction unityActionToInvokeAtEvent, PlatformerEvents platformerEventToSubscribeTo)
        {
            
        }
        
            
    }
}
