using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._012FacadePattern.GenericFacadePattern.ComplexSystems
{
    /// <summary>
    /// This will hold player details.
    /// </summary>
    public class SecondComplexSystem : MonoBehaviour
    {
        private int playerMaxHealth;
        

        public void GivePlayerFullHealth()
        {
            Debug.Log("SecondComplexSystem - 'PlayerFullHealth()' -> playerCurrentHealth = playerMaxHealth");
        }
    }
}
