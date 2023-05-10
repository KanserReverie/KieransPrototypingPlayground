namespace PrototypingPlayground._001GameDevelopmentPatterns._009DecoratorPattern.GenericDecorator
{
    // Will (wrap around) an instance another class that implements ":IDecoratableVariables"
    //
    // classExample : MonoBehaviour, IDecoratableVariables <<<--- This will NEVER change base classes properties
    
    public class ApplyDecorator : IDecoratableVariables
    {
        private readonly IDecoratableVariables decoratedClass;
        private readonly Decorator decorator;

        public ApplyDecorator(IDecoratableVariables @class, Decorator decorator) 
        {
            this.decorator = decorator;
            decoratedClass = @class;
        }
        
        // This will "Add" the decorator modifications to the base class.
        
        // Since we are only modifying property values this fits in with the decorator pattern.
        
        public float DecoratableVariable1 
        {
            get { return decoratedClass.DecoratableVariable1 + decorator.DecoratableVariable1; }
        }
        
        public float DecoratableVariable2 
        {
            get { return decoratedClass.DecoratableVariable2 + decorator.DecoratableVariable2; }
        }
        
        public float DecoratableVariable3 
        {
            get { return decoratedClass.DecoratableVariable3 + decorator.DecoratableVariable3; }
        }
    }
}
