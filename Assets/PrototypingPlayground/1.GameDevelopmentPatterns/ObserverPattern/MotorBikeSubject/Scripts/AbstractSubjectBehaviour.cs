using System.Collections;
using UnityEngine;
namespace PrototypingPlayground._1.GameDevelopmentPatterns.ObserverPattern.MotorBikeSubject.Scripts
{
    public class AbstractSubjectBehaviour : MonoBehaviour
    {
        private readonly ArrayList observers = new ArrayList();

        public void AttachObserver(AbstractObserverBehaviour _observerBehaviour)
        {
            observers.Add(_observerBehaviour);
        }

        public void DetachObserver(AbstractObserverBehaviour _observerBehaviour)
        {
            observers.Remove(_observerBehaviour);
        }

        public void NotifyObservers()
        {
            foreach (AbstractObserverBehaviour observer in observers)
            {
                observer.Notify(this);
            }
        }
    }
}
