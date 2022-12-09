using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._009DecoratorPattern.MotorBikeWeaponAttachments
{
    //
    // This is where we will create the Base/nonmodified weapons.
    //
    // These weapons will then be modified with weapon attachments when attached.  
    //
    [CreateAssetMenu(fileName = "NewWeaponConfiguration", menuName = "Weapon/Configuration", order = 1)]
    public class WeaponConfiguration : ScriptableObject, IWeapon
    {
        [Range(0, 60)]
        [Tooltip("Rate of firing per second")]
        [SerializeField] private float rate;

        [Range(0, 50)]
        [Tooltip("Weapon range")]
        [SerializeField] private float range;

        [Range(0, 100)]
        [Tooltip("Weapon strength")]
        [SerializeField] private float strength;

        [Range(0, 5)]
        [Tooltip("Cooldown duration")]
        [SerializeField] private float cooldown;

        public string weaponName;
        public GameObject weaponPrefab;
        public string weaponDescription;

        public float Rate {
            get { return rate;  }
        }

        public float Range {
            get { return range; }
        }

        public float Strength {
            get { return strength;  }
        }

        public float Cooldown {
            get { return cooldown; }
        }
    }
}