using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._008StrategyPattern.GenericStrategyPattern.ExampleImplementationCharacter
{
    public class CharacterConcreteStrategyB : MonoBehaviour, IStrategy
    {
        public void Execute()
        {
            float moveSpeed = 10f;
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        } 
    }
}