namespace PrototypingPlayground._1.GameDevelopmentPatterns._7.VisitorPattern.VisitorInterfaces
{
    public interface IVisitable
    {
        void Accept(IVisitor _visitor);
    }
}
