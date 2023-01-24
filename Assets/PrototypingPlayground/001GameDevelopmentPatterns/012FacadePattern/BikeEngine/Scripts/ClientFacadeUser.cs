using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._012FacadePattern.BikeEngine
{
    /// <summary>
    /// This will interact with the "facade" in this case the bike engine.
    /// </summary>
    public class ClientFacadeUser : MonoBehaviour
    {
        private BikeEngine bikeEngine;

        private void Start()
        {
            bikeEngine = gameObject.AddComponent<BikeEngine>();
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Turn On"))
                bikeEngine.TurnOn();

            if (GUILayout.Button("Turn Off"))
                bikeEngine.TurnOff();

            if (GUILayout.Button("Toggle Turbo"))
                bikeEngine.ToggleTurbo();
        }
    }
}
