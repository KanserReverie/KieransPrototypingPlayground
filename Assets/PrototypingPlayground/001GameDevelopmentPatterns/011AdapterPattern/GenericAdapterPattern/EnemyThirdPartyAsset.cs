using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._011AdapterPattern.GenericAdapterPattern
{
    public class EnemyThirdPartyAsset : MonoBehaviour
    {
        public int maxHealth = 100;
        public int health = 100;
        public int attackDamage = 10;

        private void Start()
        {
            Debug.Log("Enemy Class, Press: \n'a' to attack, 'x' to take 10 damage, 'space' to display stats.");
        }

        private void Update()
        {
            if (health <= 0) return;
            if (Input.GetKeyDown(KeyCode.A))
            {
                Attack();
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                TakeDamage(10);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log($"Max Health = {maxHealth} || Health = {health} || Attack Damage = {attackDamage}");
            }
        }

        public void Attack()
        {
            Debug.Log($"ThirdPartyEnemy attacked for {attackDamage} damage.");
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
            Debug.Log($"ThirdPartyEnemy took {damage} damage! \n {health} health");
            if (health <= 0)
            {
                Debug.Log("ThirdPartyEnemy has been defeated!");
            }
        }
    }
}