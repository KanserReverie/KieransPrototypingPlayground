using System.Collections;
using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._009DecoratorPattern.MotorBikeWeaponAttachments
{
    public class BikeWeapon : MonoBehaviour
    {
        public WeaponConfiguration weaponConfig;
        public WeaponAttachment mainAttachment;
        public WeaponAttachment secondaryAttachment;

        private bool isFiring;
        private IWeapon weapon;
        private bool isDecorated;

        void Start() 
        {
            // This will initialise the weapon's configuration
            weapon = new Weapon(weaponConfig);
        }
        
        // This will help with debugging mainly.
        void OnGUI()
        {
            GUI.color = Color.green;

            GUI.Label (
                new Rect (5, 50, 150, 100), 
                "Range: "+ weapon.Range);

            GUI.Label (
                new Rect (5, 70, 150, 100), 
                "Strength: "+ weapon.Strength);

            GUI.Label (
                new Rect (5, 90, 150, 100), 
                "Cooldown: "+ weapon.Cooldown);

            GUI.Label (
                new Rect (5, 110, 150, 100), 
                "Firing Rate: " + weapon.Rate);

            GUI.Label (
                new Rect (5, 130, 150, 100), 
                "Weapon Firing: " + isFiring);

            if (mainAttachment && isDecorated)
                GUI.Label (
                    new Rect (5, 150, 150, 100), 
                    "Main Attachment: " + mainAttachment.name);

            if (secondaryAttachment && isDecorated)
                GUI.Label (
                    new Rect (5, 170, 200, 100), 
                    "Secondary Attachment: " + secondaryAttachment.name);
        }
        
        public void ToggleFire() {
            isFiring = !isFiring;

            if (isFiring)
                StartCoroutine(FireWeapon());
        }

        // As you can see, you will need to toggle fire for the attachments to take effect.
        IEnumerator FireWeapon() {
            float firingRate = 1.0f / weapon.Rate;

            while (isFiring) {
                yield return new WaitForSeconds(firingRate);
                Debug.Log("fire");
            }
        }

        // This will: Weapon (RESTART) --> Weapon = new Weapon
        // Creating a new weapon...with it's default weapon configuration.
        //
        // NOTE: There are better ways to do this but this is fine for this example. 
        public void Reset() {
            weapon = new Weapon(weaponConfig);
            isDecorated = !isDecorated;
        }

        // This is where the "Decorator" pattern mechanism is triggered.
        public void Decorate() {
            if (mainAttachment && !secondaryAttachment)
            {
                weapon = new WeaponDecorator(weapon, mainAttachment);
            }
            
            if (mainAttachment && secondaryAttachment)
            {
                // We can STACK Decorators using chained constructors.
                weapon = new WeaponDecorator( new WeaponDecorator(weapon, mainAttachment), secondaryAttachment);
            }

            isDecorated = !isDecorated;
        }
    }

}
