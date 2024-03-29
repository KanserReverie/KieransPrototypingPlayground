using System.Collections;
using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._006ObserverPattern.GenericObserverPattern
{
    /// <summary> <para> This an abstract MonoBehaviour class that is part of the Observer Pattern.</para> 
    /// <para> It is for a "Subject" that will store all "Observers".</para> 
    /// <para> It will notify "Observers" when an internal change has been made.</para> </summary> 
    public abstract  class AbstractSubjectBehaviour : MonoBehaviour
    {
        private readonly ArrayList observers = new ArrayList();

        /// <summary> Add an "Observer" to the list of observers.</summary>
        /// <param name="abstractObserverBehaviour"> Observer to add.</param> 
        public void AttachObserver(AbstractObserverBehaviour abstractObserverBehaviour) => observers.Add(abstractObserverBehaviour);

        /// <summary> Remove an observer from the list of observers.</summary>
        /// <param name="abstractObserverBehaviour"> Observer to remove.</param> 
        public void DetachObserver(AbstractObserverBehaviour abstractObserverBehaviour) => observers.Remove(abstractObserverBehaviour);

        /// <summary> Will call Notify() method in each saved observer when our internal state has changed.</summary> 
        protected void NotifyObservers()
        {
            foreach (AbstractObserverBehaviour observer in observers)
            {
                observer.Notify(this);
            }
        }
    }
}
