namespace PrototypingPlayground._001GameDevelopmentPatterns._007VisitorPattern.SchoolVisitorsExample
{
    public interface IElement
    {
        void Accept(IVisitor _visitor);
    }
}
