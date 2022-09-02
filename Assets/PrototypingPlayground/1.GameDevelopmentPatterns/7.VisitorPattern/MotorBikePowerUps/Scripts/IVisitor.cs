namespace PrototypingPlayground._1.GameDevelopmentPatterns._7.VisitorPattern.MotorBikePowerUps
{
    public interface IVisitor
    {
        void Visit(BikeShield _bikeShield);
        void Visit(BikeWeapon _bikeWeapon);
        void Visit(BikeEngine _bikeEngine);
    }
}
