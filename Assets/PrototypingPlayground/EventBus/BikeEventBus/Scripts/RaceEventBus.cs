using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace PrototypingPlayground.EventBus.BikeEventBus
{
    public class RaceEventBus
    {
        private static readonly IDictionary<RaceEventType, UnityEvent> RaceEventsToUnityEventsDictionary 
            = new Dictionary<RaceEventType, UnityEvent>();

        public static void Subscribe(RaceEventType raceEventToSubscribeTo, UnityAction actionToSubscribe)
        {
            UnityEvent thisUnityEvent;
            
            if (RaceEventsToUnityEventsDictionary.TryGetValue(raceEventToSubscribeTo, out thisUnityEvent))
            {
                thisUnityEvent.AddListener(actionToSubscribe);
            }
            else
            {
                thisUnityEvent = new UnityEvent();
                thisUnityEvent.AddListener(actionToSubscribe);
                RaceEventsToUnityEventsDictionary.Add(raceEventToSubscribeTo, thisUnityEvent);
            }
        }
        public static void Unsubscribe(RaceEventType raceEventToUnsubscribeFrom, UnityAction actionToUnsubscribe)
        {
            UnityEvent thisUnityEvent;
            if (RaceEventsToUnityEventsDictionary.TryGetValue(raceEventToUnsubscribeFrom, out thisUnityEvent))
            {
                thisUnityEvent.RemoveListener(actionToUnsubscribe);
            }
        }

        public static void Publish(RaceEventType raceEventToPublish)
        {
            UnityEvent thisUnityEvent;
            if (RaceEventsToUnityEventsDictionary.TryGetValue(raceEventToPublish, out thisUnityEvent))
            {
                Debug.Log($"Running Event: {raceEventToPublish.ToString()}");
                thisUnityEvent?.Invoke();
            }
        }
    }
}