namespace PrototypingPlayground._1.GameDevelopmentPatterns._7.VisitorPattern.MotorBikePowerUps
{
    public interface IVisitor
    {
        void Visit(BikeShield _bikeShield);
        void Visit(BikeEngine _bikeEngine);
        void Visit(BikeWeapon _bikeWeapon);
    }
}
