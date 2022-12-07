using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._009DecoratorPattern.MotorBikeWeaponAttachments.Scripts
{
    //
    // The traditional Decorator pattern would normally use concrete decorator classes.
    //
    // In this case, we will use script objects.
    // This will allows us to create new attachments easily. 
    //
    [CreateAssetMenu(fileName = "NewWeaponAttachment", menuName = "Weapon/Attachment", order = 1)]
    public class WeaponAttachment : ScriptableObject, IWeapon 
    {
        [Range(0, 50)]
        [Tooltip("Increase rate of firing per second")]
        [SerializeField] public float rate;

        [Range(0, 50)]
        [Tooltip("Increase weapon range")]
        [SerializeField] float range;

        [Range(0, 100)]
        [Tooltip("Increase weapon strength")]
        [SerializeField] public float strength;

        [Range(0, -5)]
        [Tooltip("Reduce cooldown duration")]
        [SerializeField] public float cooldown;

        public string attachmentName;
        public GameObject attachmentPrefab;
        public string attachmentDescription;

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