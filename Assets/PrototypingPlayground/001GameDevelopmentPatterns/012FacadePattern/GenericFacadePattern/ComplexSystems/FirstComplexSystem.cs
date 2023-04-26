using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._012FacadePattern.GenericFacadePattern.ComplexSystems
{
    /// <summary>
    /// This will be where all the greater Gameplay Actions are
    /// </summary>
    public class FirstComplexSystem : MonoBehaviour
    {
        public void RespawnPlayer()
        {
            Debug.Log("FirstComplexSystem - 'RespawnPlayer()' -> Player teleported to respawn.");
        }
    }
}
