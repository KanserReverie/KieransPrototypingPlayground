namespace PrototypingPlayground._001GameDevelopmentPatterns._009DecoratorPattern.MotorBikeWeaponAttachments
{
    // Will (wrap around) an instance another class that implements ":IWeapon"
    //
    // classExample : MonoBehaviour, IWeapon <<<--- This will NEVER change base classes properties
    //
    public class WeaponDecorator : IWeapon
    {
        private readonly IWeapon decoratedWeapon;
        private readonly WeaponAttachment attachment;

        public WeaponDecorator(
            IWeapon weapon, WeaponAttachment attachment) {

            this.attachment = attachment;
            decoratedWeapon = weapon;
        }
        
        // Since we are only modifying property values this fits in with the decorator pattern.
        
        public float Rate {
            get { return decoratedWeapon.Rate 
                         + attachment.Rate; }
        }

        public float Range {
            get { return decoratedWeapon.Range 
                         + attachment.Range; }
        }

        public float Strength {
            get { return decoratedWeapon.Strength 
                         + attachment.Strength; }
        }

        public float Cooldown
        {
            get { return decoratedWeapon.Cooldown 
                         + attachment.Cooldown; }
        }
    }
}
