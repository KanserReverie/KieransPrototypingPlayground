using PrototypingPlayground._001GameDevelopmentPatterns._012FacadePattern.GenericFacadePattern.ComplexSystems;
using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._012FacadePattern.GenericFacadePattern
{
    /// <summary>
    /// This Facade will be for a Player Controller
    /// </summary>
    public class ExampleFacade : MonoBehaviour
    {
        private FirstComplexSystem firstComplexSystem;
        private SecondComplexSystem secondComplexSystem;
        private ThirdComplexSystem thirdComplexSystem;
        
        private void Awake()
        {
            firstComplexSystem = gameObject.AddComponent<FirstComplexSystem>();
            secondComplexSystem = gameObject.AddComponent<SecondComplexSystem>();
            thirdComplexSystem = gameObject.AddComponent<ThirdComplexSystem>();
        }

        private void Start()
        {
            Debug.Log("Press [Space] to Respawn");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RespawnPlayer();
            }
        }

        private void RespawnPlayer()
        {
            Debug.Log("Facade - 'RespawnPlayer()'");
            firstComplexSystem.RespawnPlayer();
            secondComplexSystem.GivePlayerFullHealth();
            thirdComplexSystem.ResetPlayerMovement();
        }
    }
}