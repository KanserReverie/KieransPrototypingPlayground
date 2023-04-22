using System;
using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._011AdapterPattern.GenericAdapterPattern.ExampleImplementation2
{
    public class SecondAdaptedEnemy : EnemyThirdPartyAsset
    {
        // Now if we want to make an enemy with a level up system we can drag this one in.
        // It will now be able to level up and everything else.
        public void LevelUp()
        {
            Debug.Log("Level Up!");
            maxHealth = (int) (health * 1.1f);
            health = maxHealth;
            attackDamage = (int) (attackDamage * 1.1f);
        }

        private void OnGUI()
        {
            if (health <= 0) return;
            // A simple button with a level up on screen.
            if (GUILayout.Button("Level Up Enemy"))
            {
                LevelUp();
            }

            // Make a group on the center of the screen
            GUI.BeginGroup(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 40, 300, 80));
            // All rectangles are now adjusted to the group. (0,0) is the top left corner of the group.

            // We'll make a box so you can see where the group is on-screen.
            GUI.Box(new Rect(0, 0, 300, 80), "Enemy Adapter 2");
            GUI.Box(new Rect(50, 40, 200, 30), "This Enemy can now level up.");

            // End the group we started above. This is very important to remember!
            GUI.EndGroup();
        }
    }
}