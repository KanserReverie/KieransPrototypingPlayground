using System.Collections;
using UnityEngine;
namespace PrototypingPlayground.GameDevelopmentPatterns.ObserverPattern.MotorBikeSubject
{
    public class AbstractSubject : MonoBehaviour
    {
        private readonly ArrayList observers = new ArrayList();

        public void AttachObserver(AbstractObserver _observer)
        {
            observers.Add(_observer);
        }

        public void DetachObserver(AbstractObserver _observer)
        {
            observers.Remove(_observer);
        }

        public void NotifyObservers()
        {
            foreach (AbstractObserver observer in observers)
            {
                observer.Notify(this);
            }
        }
    }
}
