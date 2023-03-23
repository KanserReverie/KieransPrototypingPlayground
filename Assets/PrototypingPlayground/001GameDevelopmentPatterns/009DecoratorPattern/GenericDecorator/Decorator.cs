using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._009DecoratorPattern.GenericDecorator
{
    /// <summary>
    /// Values this Decorator will modify.
    /// </summary>
    [CreateAssetMenu(fileName = "NewDecorator", menuName = "DecoratorPattern/Decorator", order = 1)]
    public class Decorator : ScriptableObject, IDecoratableVariables 
    {
        [Range(0, 50)] 
        [Tooltip("Modification of decoratableVariable1, if this. decorator is applied.")]
        [SerializeField] public float decoratableVariable1;

        [Range(0, 50)] 
        [Tooltip("Modification of decoratableVariable2, if this. decorator is applied.")]
        [SerializeField] public float decoratableVariable2;

        [Range(0, 100)] 
        [Tooltip("Modification of decoratableVariable3, if this. decorator is applied.")]
        [SerializeField] public float decoratableVariable3;

        public float DecoratableVariable1 
        {
            get { return decoratableVariable1; }
        }
        
        public float DecoratableVariable2 
        {
            get { return decoratableVariable2; }
        }
        
        public float DecoratableVariable3 
        {
            get { return decoratableVariable3; }
        }
    }
}
