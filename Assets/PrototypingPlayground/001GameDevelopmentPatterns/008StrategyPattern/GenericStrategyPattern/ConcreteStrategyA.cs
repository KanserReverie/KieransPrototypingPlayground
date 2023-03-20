using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._008StrategyPattern.GenericStrategyPattern
{
    // Define the first strategy implementation as a MonoBehaviour
    public class ConcreteStrategyA : MonoBehaviour, IStrategy
    {
        public void Execute()
        {
            Debug.Log("Executing strategy A");
        }
    }
}