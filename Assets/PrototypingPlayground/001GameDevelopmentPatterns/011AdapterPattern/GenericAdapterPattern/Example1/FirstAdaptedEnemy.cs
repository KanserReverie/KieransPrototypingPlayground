using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._011AdapterPattern.GenericAdapterPattern.Example1
{
    public class FirstAdaptedEnemy : EnemyThirdPartyAsset, IEnemyThirdPartyAsset
    {
        private void Awake()
        {
            maxHealth = 100;
            health = maxHealth;
            attackDamage = 10;
        }
        
        // This would allow us to now be able to attack with a crit modifier.
        public void AttackWithCrit()
        {
            // Roll a random number to determine if the attack will crit
            bool crit = Random.value < 0.2f; // 20% chance to crit

            // Call the original attack method and double the damage if it crits
            if (crit)
            {
                var normalDamage = attackDamage;
                attackDamage *= 2;
                Attack();
                Debug.Log("Critical hit!");
                attackDamage = normalDamage;
            }
            else
            {
                Attack();
            }
        }
        
        
        private void OnGUI()
        {
            if (health <= 0) return;
            // A simple button with a level up on screen.
            if (GUILayout.Button("Attack with chance to crit"))
            {
                AttackWithCrit();
            }

            // Make a group on the center of the screen
            GUI.BeginGroup(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 100, 400, 100));
            // All rectangles are now adjusted to the group. (0,0) is the topleft corner of the group.

            // We'll make a box so you can see where the group is on-screen.
            GUI.Box(new Rect(0, 0, 380, 100), "Enemy Adapter 1");
            GUI.Box(new Rect(10, 40, 360, 30), "This Enemy can now Attack with a 20% crit chance.");

            // End the group we started above. This is very important to remember!
            GUI.EndGroup();
        }
    }
}