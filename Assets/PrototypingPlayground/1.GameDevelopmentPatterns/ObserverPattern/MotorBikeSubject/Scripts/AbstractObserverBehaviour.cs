using UnityEngine;
namespace PrototypingPlayground._1.GameDevelopmentPatterns.ObserverPattern.MotorBikeSubject.Scripts
{
    public abstract class AbstractObserverBehaviour : MonoBehaviour
    {
        public abstract void Notify(AbstractSubjectBehaviour _subjectBehaviour);
    }
}
