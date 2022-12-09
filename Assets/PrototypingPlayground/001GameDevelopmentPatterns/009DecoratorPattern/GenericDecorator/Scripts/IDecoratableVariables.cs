namespace PrototypingPlayground._001GameDevelopmentPatterns._009DecoratorPattern.GenericDecorator
{
    /// <summary>
    /// This will be implemented by the decorators and the base class.
    /// </summary>
    public interface IDecoratableVariables
    {
        // These are the properties we can decorate.
        float DecoratableVariable1 { get; }
        float DecoratableVariable2 { get; }
        float DecoratableVariable3 { get; }
        float DecoratableVariable4 { get; }
    }
}
