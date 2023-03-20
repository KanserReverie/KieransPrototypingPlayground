using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._008StrategyPattern.GenericStrategyPattern
{
    // Define the second strategy implementation as a MonoBehaviour
    public class ConcreteStrategyB : MonoBehaviour, IStrategy
    {
        public void Execute()
        {
            Debug.Log("Executing strategy B");
        }
    }
}