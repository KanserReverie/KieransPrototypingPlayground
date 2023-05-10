namespace PrototypingPlayground._001GameDevelopmentPatterns._007VisitorPattern.MotorBikePowerUps
{
    public interface IVisitor
    {
        void Visit(BikeShield bikeShield);
        void Visit(BikeWeapon bikeWeapon);
        void Visit(BikeEngine bikeEngine);
    }
}
