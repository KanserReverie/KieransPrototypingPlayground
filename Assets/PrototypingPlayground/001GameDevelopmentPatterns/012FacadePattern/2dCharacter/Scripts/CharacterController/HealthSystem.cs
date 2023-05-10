using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._012FacadePattern._2dCharacter.CharacterController
{
    public class HealthSystem : MonoBehaviour
    {
        private float currentHealth;
        private float startingHealth;
        private bool aliveStatus;

        public bool IsPlayerAlive => aliveStatus;
        
        public void SpawnPlayer(float startingHealth)
        {
            aliveStatus = true;
            this.startingHealth = startingHealth;
            currentHealth = this.startingHealth;
        }
        
        public void KillPlayer()
        {
            aliveStatus = false;
            currentHealth = 0;
        }

        private void OnGUI()
        {
            if (aliveStatus)
            {
                GUILayout.Label($"Health {currentHealth}", new GUIStyle("box"));
            }
        }
    }
}
