using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._012FacadePattern.GenericFacadePattern.ComplexSystems
{
    /// <summary>
    /// This will hold player details.
    /// </summary>
    public class SecondComplexSystem : MonoBehaviour
    {
        private int playerMaxHealth;
        private int playerCurrentHealth;

        public void GivePlayerFullHealth()
        {
            playerCurrentHealth = playerMaxHealth;
            Debug.Log("SecondComplexSystem - 'PlayerFullHealth()' -> playerCurrentHealth = playerMaxHealth");
        }
    }
}
