using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._011AdapterPattern.GenericAdapterPattern.ExampleImplementation
{
    public class FirstAdaptedEnemy : EnemyThirdPartyAsset, IEnemyThirdPartyAsset
    {
        private readonly EnemyThirdPartyAsset enemyThirdPartyAsset;

        public FirstAdaptedEnemy(EnemyThirdPartyAsset _enemy)
        {
            this.enemyThirdPartyAsset = _enemy;
        }
        
        // This would allow us to now be able to attack with a crit modifier.
        public void AttackWithCrit()
        {
            // Roll a random number to determine if the attack will crit
            bool crit = Random.value < 0.1f; // 10% chance to crit

            // Call the original attack method and double the damage if it crits
            if (crit)
            {
                var normalDamage = enemyThirdPartyAsset.attackDamage;
                enemyThirdPartyAsset.attackDamage *= 2;
                enemyThirdPartyAsset.Attack();
                Debug.Log("Critical hit!");
                enemyThirdPartyAsset.attackDamage = normalDamage;
            }
            else
            {
                enemyThirdPartyAsset.Attack();
            }
        }
    }
}