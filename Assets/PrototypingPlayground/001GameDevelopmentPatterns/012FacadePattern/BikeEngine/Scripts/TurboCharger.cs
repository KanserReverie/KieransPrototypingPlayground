using System.Collections;
using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._012FacadePattern.BikeEngine
{
    public class TurboCharger : MonoBehaviour
    {
        public BikeEngine engine;
        
        private bool isTurboOn;
        private CoolingSystem coolingSystem;

        public void ToggleTurbo(CoolingSystem _coolingSystem)
        {
            this.coolingSystem = _coolingSystem;
            
            if (!isTurboOn)
                StartCoroutine(TurboCharge());
        }

        private IEnumerator TurboCharge()
        {
            isTurboOn = true;
            coolingSystem.PauseCooling();

            yield return new WaitForSeconds(engine.turboDuration);

            isTurboOn = false;
            coolingSystem.PauseCooling();
        }

        private void OnGUI()
        {
            GUI.color = Color.green;
            GUI.Label(new Rect(100, 60, 500, 20), "Turbo Activated: " +  isTurboOn);
        }
    }
}
