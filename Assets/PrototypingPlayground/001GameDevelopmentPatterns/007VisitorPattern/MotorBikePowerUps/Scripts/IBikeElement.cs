namespace PrototypingPlayground._001GameDevelopmentPatterns._007VisitorPattern.MotorBikePowerUps
{
    public interface IBikeElement
    {
        void Accept(IVisitor _visitor);
    }
}
