using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._008StrategyPattern.FighterDrones
{
    public interface IDroneStrategy
    {
        void ImplementStrategy(Drone _drone);
    }
}
