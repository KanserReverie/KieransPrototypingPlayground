using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._007VisitorPattern.MotorBikePowerUps
{
    public class ClientVisitor : MonoBehaviour
    {
        // Adding 3 different types of power ups.
        public PowerUp enginePowerUp;
        public PowerUp shieldPowerUp;
        public PowerUp weaponPowerUp;

        // Adding a bike controller.
        private BikeController bikeController;

        void Start()
        {
            bikeController = gameObject.AddComponent<BikeController>();
        }

        void OnGUI()
        {
            // Gets the bike controller and lets it be visited by one of these 3 power ups.
            
            if (GUILayout.Button("PowerUp Shield"))
                bikeController.Accept(shieldPowerUp);

            if (GUILayout.Button("PowerUp Engine"))
                bikeController.Accept(enginePowerUp);

            if (GUILayout.Button("PowerUp Weapon"))
                bikeController.Accept(weaponPowerUp);
        }
    }
}
