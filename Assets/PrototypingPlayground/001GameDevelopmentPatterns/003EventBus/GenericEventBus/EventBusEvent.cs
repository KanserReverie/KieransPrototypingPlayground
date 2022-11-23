using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._003EventBus.GenericEventBus
{
    /// <summary>
    /// All your events  able used in the EventBus.
    /// </summary>
    public enum EventBusEvent
    {
        Event1, Event2, Event3, Event4, Event5 //  <--- You would any events you would like to trigger to this list.
        
        // An example would be:
        // COUNTDOWN, START, RESTART, PAUSE, STOP, FINISH, END
        // or
        // COUNTDOWN, START, RESTART, DIE, FINISH
    }
}
