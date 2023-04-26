using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._012FacadePattern.GenericFacadePattern.ComplexSystems
{
    /// <summary>
    /// This will hold player movement details.
    /// </summary>
    public class ThirdComplexSystem : MonoBehaviour
    {
        public void ResetPlayerMovement()
        {
            Debug.Log("ThirdComplexSystem - 'ResetPlayerMovement()' -> Player Movement Reset");
        }
    }
}
