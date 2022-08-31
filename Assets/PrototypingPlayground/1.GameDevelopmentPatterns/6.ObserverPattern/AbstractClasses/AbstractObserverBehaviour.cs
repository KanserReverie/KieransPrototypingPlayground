using UnityEngine;
namespace PrototypingPlayground._1.GameDevelopmentPatterns._6.ObserverPattern.AbstractClasses
{
    /// <summary> <para> This an abstract MonoBehaviour class that is part of the Observer Pattern.</para>
    /// <para> It is for an "Observer" that subscribe to a "Subject".</para>
    /// <para> It will be notified when a change has been made in the Subject.</para> </summary>
    public abstract class AbstractObserverBehaviour : MonoBehaviour
    {
        /// <summary> Triggered when a change in the "Subject" is made. </summary>
        /// <param name="_abstractSubjectBehaviour">The current state of the "Subject".</param>
        public abstract void Notify(AbstractSubjectBehaviour _abstractSubjectBehaviour);
    }
}
