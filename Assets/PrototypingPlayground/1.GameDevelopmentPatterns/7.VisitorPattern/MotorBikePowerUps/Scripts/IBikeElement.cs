namespace PrototypingPlayground._1.GameDevelopmentPatterns._7.VisitorPattern.MotorBikePowerUps
{
    public interface IBikeElement
    {
        void Accept(IVisitor _visitor);
    }
}
