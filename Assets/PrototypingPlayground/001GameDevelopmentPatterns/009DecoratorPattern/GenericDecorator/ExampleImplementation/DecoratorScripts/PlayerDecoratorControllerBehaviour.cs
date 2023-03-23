using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace PrototypingPlayground._001GameDevelopmentPatterns._009DecoratorPattern.GenericDecorator.ExampleImplementation.DecoratorScripts
{
    // Attach this to the player GameObject to add and remove decorators.
    [RequireComponent(typeof(NewPlayer))]
    public class PlayerDecoratorControllerBehaviour : MonoBehaviour
    {
        private NewPlayer newPlayer;
        [SerializeField] private PlayerDecorator decorator1;
        [SerializeField] private PlayerDecorator decorator2;
        [SerializeField] private PlayerDecorator decorator3;
        private void Start()
        {
            newPlayer = GetComponent<NewPlayer>();
            Assert.IsNotNull(decorator1);
            Assert.IsNotNull(decorator2);
            Assert.IsNotNull(decorator3);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) { Debug.Log($"Add Decorator 1 - {decorator1.name}"); newPlayer.playerDecorators.Add(decorator1); }
            if (Input.GetKeyDown(KeyCode.Alpha2)) { Debug.Log($"Add Decorator 2 - {decorator2.name}"); newPlayer.playerDecorators.Add(decorator2); }
            if (Input.GetKeyDown(KeyCode.Alpha3)) { Debug.Log($"Add Decorator 3 - {decorator3.name}"); newPlayer.playerDecorators.Add(decorator3); }
            if (Input.GetKeyDown(KeyCode.R)) { Debug.Log("Remove All Decorators"); newPlayer.playerDecorators = new List<IPlayerDecoratableVariables>(); }
        }
    }
}