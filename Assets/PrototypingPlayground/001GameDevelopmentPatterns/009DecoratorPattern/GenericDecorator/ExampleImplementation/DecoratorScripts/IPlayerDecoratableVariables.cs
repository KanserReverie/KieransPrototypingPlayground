namespace PrototypingPlayground._001GameDevelopmentPatterns._009DecoratorPattern.GenericDecorator.ExampleImplementation.DecoratorScripts
{
    public interface IPlayerDecoratableVariables
    {
        // These are the properties we can decorate.
        float MovementSpeed { get; }
        float JumpHeight { get; }
        float Damage { get; }
    }
}