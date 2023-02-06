using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._013ServiceLocatorPattern.UnityServices
{
    public class Advertisement : IAdvertisement
    {
        public void DisplayAdvertisement()
        {
            Debug.Log("Displaying video advertisement");
        }
    }
}