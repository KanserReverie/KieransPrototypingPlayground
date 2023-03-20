using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._008StrategyPattern.GenericStrategyPattern.ExampleImplementationCharacter
{
    public class CharacterConcreteStrategyA : MonoBehaviour, IStrategy
    {
        public void Execute()
        {
            float moveSpeed = 5f;
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }
}