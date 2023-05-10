using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._006ObserverPattern.GenericObserverPattern
{
    /// <summary> <para> This an abstract MonoBehaviour class that is part of the Observer Pattern.</para>
    /// <para> It is for an "Observer" that subscribe to a "Subject".</para>
    /// <para> It will be notified when a change has been made in the Subject.</para> </summary>
    public abstract class AbstractObserverBehaviour : MonoBehaviour
    {
        /// <summary> Triggered when the "Subject" state changes. </summary>
        /// <param name="abstractSubjectBehaviour">The current state of the "Subject".</param>
        public abstract void Notify(AbstractSubjectBehaviour abstractSubjectBehaviour);
    }
}
