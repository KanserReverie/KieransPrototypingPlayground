using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._012FacadePattern.BikeEngine
{
    /// <summary>
    /// This is the facade that a client interacts with that will link upto the 3 complex systems.
    ///
    /// Cooling System, Fuel Pump and Turbo Charger
    /// </summary>
    public class BikeEngine : MonoBehaviour
    {
        public float burnRate = 1.0f;
        public float fuelAmount = 100.0f;
        public float tempRate = 5.0f;
        public float minTemp = 50.0f;
        public float maxTemp = 65.0f;
        public float currentTemp;
        public float turboDuration = 2.0f;

        private bool isEngineOn;
        private FuelPump fuelPump;
        private TurboCharger turboCharger;
        private CoolingSystem coolingSystem;

        private void Awake()
        {
            fuelPump = gameObject.AddComponent<FuelPump>();
            turboCharger = gameObject.AddComponent<TurboCharger>();
            coolingSystem = gameObject.AddComponent<CoolingSystem>();
        }

        private void Start()
        {
            fuelPump.engine = this;
            turboCharger.engine = this;
            coolingSystem.engine = this;
        }
        
        public void TurnOn()
        {
            isEngineOn = true;
            StartCoroutine(fuelPump.BurnFuel);
            StartCoroutine(coolingSystem.CoolEngine);
        }

        public void TurnOff()
        {
            isEngineOn = false;
            coolingSystem.ResetTemperature();
            StopCoroutine(fuelPump.BurnFuel);
            StopCoroutine(coolingSystem.CoolEngine);
        }

        public void ToggleTurbo()
        {
            if (isEngineOn)
                turboCharger.ToggleTurbo(coolingSystem);
        }

        private void OnGUI()
        {
            GUI.color = Color.green;
            
            GUI.Label(new Rect(100, 0, 500, 20), "Engine Running: " + isEngineOn);
        }
    }
}
