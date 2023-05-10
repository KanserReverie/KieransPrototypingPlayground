namespace PrototypingPlayground._001GameDevelopmentPatterns._009DecoratorPattern.GenericDecorator
{
    /// <summary>
    /// This is the DecoratableClass that will be able to have its properties overriden with a decorator.
    /// </summary>
    public class DecoratableClass : IDecoratableVariables
    {
        private readonly BaseValues baseValues;

        public DecoratableClass(BaseValues baseValues)
        {
            this.baseValues = baseValues;
        }
        
        public float DecoratableVariable1
        {
            get { return baseValues.DecoratableVariable1; }
        }

        public float DecoratableVariable2
        {
            get { return baseValues.DecoratableVariable2; }
        }

        public float DecoratableVariable3
        {
            get { return baseValues.DecoratableVariable3; }
        }
    }
}
