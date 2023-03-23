using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._009DecoratorPattern.GenericDecorator.ExampleImplementation.DecoratorScripts
{
    [CreateAssetMenu(fileName = "PlayerDecorator", menuName = "DecoratorPattern/ExampleImplementation/PlayerDecorator", order = 1)]

    public class PlayerDecorator : ScriptableObject, IPlayerDecoratableVariables
    {
        [Header("These are how much the decorators will get boosted by")]
        [SerializeField] public float movementSpeedBoost;
        [SerializeField] public float jumpHeightBoost;
        [SerializeField] public float damageBoost;
        
        public float MovementSpeed => movementSpeedBoost;
        public float JumpHeight => jumpHeightBoost;
        public float Damage => damageBoost;
    }
}