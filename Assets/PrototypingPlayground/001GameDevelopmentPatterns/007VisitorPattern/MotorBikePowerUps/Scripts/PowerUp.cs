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

        public void Visit(BikeShield _bikeShield)
        {
            if (healShield)
            {
                _bikeShield.health = 100.0f;
            }
        }
        public void Visit(BikeWeapon _bikeWeapon)
        {
            int range = _bikeWeapon.range += weaponRange;

            if (range >= _bikeWeapon.maxRange)
            {
                _bikeWeapon.range = _bikeWeapon.maxRange;
            }
            else
            {
                _bikeWeapon.range = range;
            }

            float strength = _bikeWeapon.strength += Mathf.Round(_bikeWeapon.strength * weaponStrength / 100);

            if (strength >= _bikeWeapon.maxStrength)
            {
                _bikeWeapon.strength = _bikeWeapon.maxStrength;
            }
            else
            {
                _bikeWeapon.strength = strength;
            }
        }
        public void Visit(BikeEngine _bikeEngine)
        {
            float boost = _bikeEngine.turboBoost += turboBoost;

            if (boost < 0.0f)
            {
                _bikeEngine.turboBoost = 0.0f;
            }

            if (boost >= _bikeEngine.maxTurboBoost)
            {
                _bikeEngine.turboBoost = _bikeEngine.maxTurboBoost;
            }
        }
    }
}