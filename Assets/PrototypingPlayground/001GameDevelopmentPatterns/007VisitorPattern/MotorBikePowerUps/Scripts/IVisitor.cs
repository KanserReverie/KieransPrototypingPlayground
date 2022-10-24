namespace PrototypingPlayground._001GameDevelopmentPatterns._007VisitorPattern.MotorBikePowerUps
{
    public interface IVisitor
    {
        void Visit(BikeShield _bikeShield);
        void Visit(BikeWeapon _bikeWeapon);
        void Visit(BikeEngine _bikeEngine);
    }
}
