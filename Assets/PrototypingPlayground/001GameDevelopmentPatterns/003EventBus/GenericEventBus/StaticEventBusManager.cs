using System.Collections.Generic;
using UnityEngine.Events;
namespace PrototypingPlayground._001GameDevelopmentPatterns._003EventBus.GenericEventBus
{
    /// <summary>
    ///
    /// A static class you will use to Subscribe, Unsubscribe and Publish EventBusEvents.
    /// 
    /// To be used when you have GameEvents where lots of things are meant to trigger. (e.g. "PlayerDeath" "StartRace" "FinishGame")
    ///
    /// </summary>
    public static class StaticEventBusManager
    {
        // Quick note: Unity Events vs Unity Action.
        //
        // Unity Events:
        // - Serializable
        // - Event System
        // - Holds multiple Unity Actions
        // - Can only be Invoked PRIVATELY.
        // - ... but Unity Actions added and subtracted to PUBLICLY, thus higher security.
        // - Use to trigger multiple EXTERNAL Unity Actions.
        // - EXAMPLE - A Button in Unity where you can trigger multiple Unity Actions on other gameobjects. 
        //
        // Unity Action:
        // - Simple pre-made Delegates
        // - Not as Expensive
        // - Parameters
        // - Should be used PRIVATELY/INTERNALLY and then added to PUBLIC/EXTERNAL Unity Events.
        
        /// <summary>
        /// <para> Holds all EventBusEvents and any corresponding UnityEvents.</para>
        ///
        /// <para> We Subscribe and Unsubscribe UnityActions to our UnityEvents.</para>
        /// 
        /// <para> When a EventBusEvent is Published any/all UnityActions in corresponding UnityEvent will be Invoked.</para>
        /// </summary> 
        private static readonly IDictionary<EventBusEvent, UnityEvent> EventBusEventsToUnityEventsDictionary = new Dictionary<EventBusEvent, UnityEvent>();
        
        
        /// <summary>
        /// <para>Adds an UnityAction to be called when selected **<b>EventBusEvent</b> is published.</para>
        /// 
        /// <para>**<i>StaticEventBusManager.Publish(EventBusEvent)</i></para>
        /// </summary>
        /// 
        /// <param name="eventBusEventToSubscribeTo"> When this EventBusEvent is published your UnityAction will be called.</param>
        /// <param name="unityActionToSubscribe"> The UnityAction that will be Invoked when EventBusEvent is called.</param>
        /// 
        public static void Subscribe(EventBusEvent eventBusEventToSubscribeTo, UnityAction unityActionToSubscribe)
        {
            UnityEvent thisUnityEvent;

            if (EventBusEventsToUnityEventsDictionary.TryGetValue(eventBusEventToSubscribeTo, out thisUnityEvent))
            {
                thisUnityEvent.AddListener(unityActionToSubscribe);
            }
            else
            {
                thisUnityEvent = new UnityEvent();
                thisUnityEvent.AddListener(unityActionToSubscribe);
                EventBusEventsToUnityEventsDictionary.Add(eventBusEventToSubscribeTo, thisUnityEvent);
            }
        }
        
        /// <summary> 
        /// <para> Removes an UnityAction from selected EventBusEvent.</para> 
        /// </summary> 
        /// <param name="eventBusEventToUnsubscribeFrom"> The EventBusEvent you are removing selected UnityAction from.</param> 
        /// <param name="unityActionToUnsubscribe"> The UnityAction to be removed.</param>
        /// 
        public static void Unsubscribe(EventBusEvent eventBusEventToUnsubscribeFrom, UnityAction unityActionToUnsubscribe)
        {
            UnityEvent thisUnityEvent;
            if (EventBusEventsToUnityEventsDictionary.TryGetValue(eventBusEventToUnsubscribeFrom, out thisUnityEvent))
            {
                thisUnityEvent.RemoveListener(unityActionToUnsubscribe);
            }
        }

        /// <summary>
        /// <para> Publishes selected EventBusEvent.</para>
        /// 
        /// <para> This will Invoke all UnityActions linked to this event.</para>
        /// </summary>
        /// <param name="eventBusEventToPublish"> The EventBusEvent to publish.</param>
        /// 
        public static void Publish(EventBusEvent eventBusEventToPublish)
        {
            UnityEvent thisUnityEvent;
            if (EventBusEventsToUnityEventsDictionary.TryGetValue(eventBusEventToPublish, out thisUnityEvent))
            {
                thisUnityEvent?.Invoke();
            }
        }
    }
}
