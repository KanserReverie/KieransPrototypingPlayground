using UnityEngine;

namespace PrototypingPlayground._1.GameDevelopmentPatterns._7.VisitorPattern.MotorBikePowerUps
{
    public class ClientVisitor : MonoBehaviour
    {
        // Adding 3 different types of power ups.
        public PowerUp enginePowerUp;
        public PowerUp shieldPowerUp;
        public PowerUp weaponPowerUp;

        // Adding a bike controller.
        private BikeController _bikeController;

        void Start()
        {
            _bikeController = gameObject.AddComponent<BikeController>();
        }

        void OnGUI()
        {
            // Gets the bike controller and lets it be visited by one of these 3 power ups.
            
            if (GUILayout.Button("PowerUp Shield"))
                _bikeController.Accept(shieldPowerUp);

            if (GUILayout.Button("PowerUp Engine"))
                _bikeController.Accept(enginePowerUp);

            if (GUILayout.Button("PowerUp Weapon"))
                _bikeController.Accept(weaponPowerUp);
        }
    }
}
