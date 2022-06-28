using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace PrototypingPlayground.EventBus.PlatformerEventBus
{
    public class PlatformerGameManagerEventBus : MonoBehaviour
    {
        private readonly IDictionary<PlatformerEvents, UnityEvent> _platformerEventsToUnityEvents = new Dictionary<PlatformerEvents, UnityEvent>();

        public void SubscribeActionToEvent (UnityAction unityActionToInvoke, PlatformerEvents platformerEvent)
        {
            UnityEvent tempUnityEvent;
            if (_platformerEventsToUnityEvents.TryGetValue(platformerEvent, out tempUnityEvent))
            {
                tempUnityEvent.AddListener(unityActionToInvoke);
            }
            else
            {
                tempUnityEvent = new UnityEvent();
                tempUnityEvent.AddListener(unityActionToInvoke);
                _platformerEventsToUnityEvents.Add(platformerEvent, tempUnityEvent);
            }
        }

        public void UnsubscribeActionFromEvent(UnityAction unityAction, PlatformerEvents platformerEvent)
        {
            UnityEvent tempUnityEvent;
            if (_platformerEventsToUnityEvents.TryGetValue(platformerEvent, out tempUnityEvent))
            {
                tempUnityEvent.RemoveListener(unityAction);
            }
        }

        public void PublishEvent(PlatformerEvents platformerEvent)
        {
            UnityEvent tempUnityEvent;
            if (_platformerEventsToUnityEvents.TryGetValue(platformerEvent, out tempUnityEvent))
            {
                tempUnityEvent?.Invoke();
            }
        }

        public static PlatformerGameManagerEventBus FindEventBusInScene()
        {
            PlatformerGameManagerEventBus ScenePlatformerGameManagerEventBus = null;
            ScenePlatformerGameManagerEventBus = FindObjectOfType<PlatformerGameManagerEventBus>();
            
            if(ScenePlatformerGameManagerEventBus == null)
            {
                GameObject tempPlatformerEventBus;
                tempPlatformerEventBus = new GameObject("tempPlatformerEventBus");
                ScenePlatformerGameManagerEventBus = tempPlatformerEventBus.AddComponent<PlatformerGameManagerEventBus>();
            }
            
            return ScenePlatformerGameManagerEventBus;
        }
    }
}
