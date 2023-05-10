using System.Collections;
using UnityEngine;
// ReSharper disable All

namespace PrototypingPlayground._001GameDevelopmentPatterns._012FacadePattern.BikeEngine
{
    public class CoolingSystem : MonoBehaviour
    {
        public BikeEngine engine;
        public IEnumerator CoolEngine;
        private bool isPaused;

        private void Start()
        {
            CoolEngine = CoolDownEngine();
        }

        public void PauseCooling() 
        {
            isPaused = !isPaused;
        }

        public void ResetTemperature() 
        {
            engine.currentTemp = 0.0f;
        }

        private IEnumerator CoolDownEngine() {
            while (true) {
                yield return new WaitForSeconds(1);

                if (!isPaused) {
                    if (engine.currentTemp > engine.minTemp)
                        engine.currentTemp -= engine.tempRate;
                    if (engine.currentTemp < engine.minTemp)
                        engine.currentTemp += engine.tempRate;
                } else {
                    engine.currentTemp += engine.tempRate;
                }

                if (engine.currentTemp > engine.maxTemp)
                    engine.TurnOff();
            }
        }

        private void OnGUI() {
            GUI.color = Color.green;
            GUI.Label(
                new Rect(100, 20, 500, 20), 
                "Temp: " +  engine.currentTemp);
        }
    }
}
