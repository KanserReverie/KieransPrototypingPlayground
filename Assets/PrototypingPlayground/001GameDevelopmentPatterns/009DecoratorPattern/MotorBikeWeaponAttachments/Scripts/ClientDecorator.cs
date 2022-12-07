using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._009DecoratorPattern.MotorBikeWeaponAttachments.Scripts
{
    public class ClientDecorator : MonoBehaviour
    {
        private BikeWeapon bikeWeapon;
        private bool isWeaponDecorated;

        private void Start() {
            bikeWeapon = 
                (BikeWeapon) 
                FindObjectOfType(typeof(BikeWeapon));
        }

        private void OnGUI() 
        {
            if (!isWeaponDecorated) 
                if (GUILayout.Button("Decorate Weapon")) {
                    bikeWeapon.Decorate();
                    isWeaponDecorated = !isWeaponDecorated;
                }

            if (isWeaponDecorated)
                if (GUILayout.Button("Reset Weapon")) {
                    bikeWeapon.Reset();
                    isWeaponDecorated = !isWeaponDecorated;
                }

            if (GUILayout.Button("Toggle Fire"))
                bikeWeapon.ToggleFire();
        }
    }
}
