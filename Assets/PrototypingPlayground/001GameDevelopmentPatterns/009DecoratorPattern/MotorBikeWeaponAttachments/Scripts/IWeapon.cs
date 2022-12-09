namespace PrototypingPlayground._001GameDevelopmentPatterns._009DecoratorPattern.MotorBikeWeaponAttachments
{
    public interface IWeapon
    {
        // These are the properties we can decorate.
        float Range { get; }
        float Rate { get; }
        float Strength { get; }
        float Cooldown { get; }
    }
}