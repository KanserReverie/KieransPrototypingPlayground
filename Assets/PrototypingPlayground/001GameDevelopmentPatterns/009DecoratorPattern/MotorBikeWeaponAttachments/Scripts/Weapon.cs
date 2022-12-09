namespace PrototypingPlayground._001GameDevelopmentPatterns._009DecoratorPattern.MotorBikeWeaponAttachments
{
    // Unlike BikeWeapon... This is just the configurable properties of a weapon.
    public class Weapon : IWeapon
    { 
        public float Range
        {
            get { return configuration.Range; }
        }

        public float Rate
        {
            get { return configuration.Rate; }
        }

        public float Strength
        {
            get { return configuration.Strength; }
        }

        public float Cooldown
        {
            get { return configuration.Cooldown; }
        }

        private readonly WeaponConfiguration configuration;

        public Weapon(WeaponConfiguration _weaponConfiguration)
        {
            configuration = _weaponConfiguration;
        }
    }
}
