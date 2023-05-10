using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._007VisitorPattern.MotorBikePowerUps
{
    [CreateAssetMenu(fileName = "PowerUp", menuName = "PowerUp", order = 0)]
    public class PowerUp : ScriptableObject, IVisitor
    {
        public string powerUpName;
        public GameObject powerUpPrefab;
        public string powerUpDescription;

        [Tooltip("Fully heal shield")]
        public bool healShield;

        [Tooltip("Boost turbo settings up to increments of 50km/h")] [Range(0.0f, 50.0f)]
        public float turboBoost;

        [Tooltip("Boost weapon range in increments of upto 25 units")] [Range(0.0f, 25)]
        public int weaponRange;

        [Tooltip("Boost weapon strength in increments upto 50%")] [Range(0.0f, 50.0f)]
        public float weaponStrength;

        public void Visit(BikeShield bikeShield)
        {
            if (healShield)
            {
                bikeShield.health = 100.0f;
            }
        }
        public void Visit(BikeWeapon bikeWeapon)
        {
            int range = bikeWeapon.range += weaponRange;

            if (range >= bikeWeapon.maxRange)
            {
                bikeWeapon.range = bikeWeapon.maxRange;
            }
            else
            {
                bikeWeapon.range = range;
            }

            float strength = bikeWeapon.strength += Mathf.Round(bikeWeapon.strength * weaponStrength / 100);

            if (strength >= bikeWeapon.maxStrength)
            {
                bikeWeapon.strength = bikeWeapon.maxStrength;
            }
            else
            {
                bikeWeapon.strength = strength;
            }
        }
        public void Visit(BikeEngine bikeEngine)
        {
            float boost = bikeEngine.turboBoost += turboBoost;

            if (boost < 0.0f)
            {
                bikeEngine.turboBoost = 0.0f;
            }

            if (boost >= bikeEngine.maxTurboBoost)
            {
                bikeEngine.turboBoost = bikeEngine.maxTurboBoost;
            }
        }
    }
}