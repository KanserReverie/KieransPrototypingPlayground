using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace PrototypingPlayground._001GameDevelopmentPatterns._003EventBus.PlatformerEventBus
{
    public class GameManagerEventBus : MonoBehaviour
    {
        private readonly IDictionary<PlatformerEvents, UnityEvent> platformerEventsToUnityEvents = new Dictionary<PlatformerEvents, UnityEvent>();

        public void SubscribeActionToEvent (UnityAction unityActionToInvoke, PlatformerEvents platformerEvent)
        {
            UnityEvent tempUnityEvent;
            if (platformerEventsToUnityEvents.TryGetValue(platformerEvent, out tempUnityEvent))
            {
                tempUnityEvent.AddListener(unityActionToInvoke);
            }
            else
            {
                tempUnityEvent = new UnityEvent();
                tempUnityEvent.AddListener(unityActionToInvoke);
                platformerEventsToUnityEvents.Add(platformerEvent, tempUnityEvent);
            }
        }

        public void UnsubscribeActionFromEvent(UnityAction unityAction, PlatformerEvents platformerEvent)
        {
            UnityEvent tempUnityEvent;
            if (platformerEventsToUnityEvents.TryGetValue(platformerEvent, out tempUnityEvent))
            {
                tempUnityEvent.RemoveListener(unityAction);
            }
        }

        public void PublishEvent(PlatformerEvents platformerEvent)
        {
            UnityEvent tempUnityEvent;
            if (platformerEventsToUnityEvents.TryGetValue(platformerEvent, out tempUnityEvent))
            {
                tempUnityEvent?.Invoke();
            }
        }

        public static GameManagerEventBus FindEventBusInScene()
        {
            GameManagerEventBus sceneGameManagerEventBus;
            sceneGameManagerEventBus = FindObjectOfType<GameManagerEventBus>();
            
            if(sceneGameManagerEventBus == null)
            {
                GameObject tempPlatformerEventBus;
                tempPlatformerEventBus = new GameObject("tempPlatformerEventBus");
                sceneGameManagerEventBus = tempPlatformerEventBus.AddComponent<GameManagerEventBus>();
            }
            
            return sceneGameManagerEventBus;
        }
    }
}
