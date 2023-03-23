using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._009DecoratorPattern.GenericDecorator
{
    /// <summary>
    /// Base value configuration before any decorations are applied.
    /// </summary>
    [CreateAssetMenu(fileName = "NewBaseValues", menuName = "DecoratorPattern/BaseValues", order = 1)]
    public class BaseValues : ScriptableObject, IDecoratableVariables
    {

        [Range(0, 50)]
        [Tooltip("Base value of decoratableVariable1, if this. scriptable object is used.")]
        [SerializeField] public float decoratableVariable1;

        [Range(0, 50)]
        [Tooltip("Base value of decoratableVariable2, if this. scriptable object is used.")]
        [SerializeField] public float decoratableVariable2;

        [Range(0, 100)]
        [Tooltip("Base value of decoratableVariable3, if this. scriptable object is used.")]
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
