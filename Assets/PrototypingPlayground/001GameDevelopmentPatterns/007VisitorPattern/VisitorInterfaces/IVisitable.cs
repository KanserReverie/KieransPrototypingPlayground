namespace PrototypingPlayground._001GameDevelopmentPatterns._007VisitorPattern.VisitorInterfaces
{
    public interface IVisitable
    {
        void Accept(IVisitor _visitor);
    }
}
