using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._011AdapterPattern.GenericAdapterPattern
{
    public class EnemyThirdPartyAsset : MonoBehaviour
    {
        private int health = 100;
        public int attackDamage = 10;

        public void Attack()
        {
            Debug.Log($"ThirdPartyEnemy attacked for {attackDamage} damage.");
        }

        public int GetHealth()
        {
            return health;
        }

        public void TakeDamage(int _damage)
        {
            health -= _damage;
            if (health <= 0)
            {
                Debug.Log("ThirdPartyEnemy has been defeated!");
            }
        }
    }
}