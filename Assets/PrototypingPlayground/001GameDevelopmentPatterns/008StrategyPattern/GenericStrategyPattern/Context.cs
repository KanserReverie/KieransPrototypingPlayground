using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._008StrategyPattern.GenericStrategyPattern
{
    // Define the context class as a MonoBehaviour
    public class Context : MonoBehaviour
    {
        private IStrategy strategy;

        public void SetStrategy(IStrategy _strategy)
        {
            this.strategy = _strategy;
        }

        public void ExecuteStrategy()
        {
            strategy.Execute();
        }
    }
}