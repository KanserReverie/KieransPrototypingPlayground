using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._013ServiceLocatorPattern.GenericServiceLocatorPattern.Services
{
    public abstract class MonoRegistrable : MonoBehaviour, IRegistrable
    {
        protected void Reset()
        {
            name = GetType().Name;
        }
    }
}
