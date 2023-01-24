using System.Collections;

using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._012FacadePattern.BikeEngine
{
    public class FuelPump : MonoBehaviour
    {
        public BikeEngine engine;
        public IEnumerator burnFuel;

        private void Start()
        {
            burnFuel = BurnFuel();
        }

        private IEnumerator BurnFuel()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                engine.fuelAmount -= engine.burnRate;

                if (engine.fuelAmount <= 0.0f) 
                {
                    engine.TurnOff();
                    yield return 0;
                }
            }
        }

        private void OnGUI()
        {
            GUI.color = Color.green;
            
            GUI.Label(new Rect(100, 40, 500, 20), "Fuel: " +  engine.fuelAmount);
        }
    }
}
