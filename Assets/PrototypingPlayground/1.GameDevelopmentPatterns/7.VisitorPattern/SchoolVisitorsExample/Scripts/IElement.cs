namespace PrototypingPlayground._1.GameDevelopmentPatterns._7.VisitorPattern.SchoolVisitorsExample
{
    public interface IElement
    {
        void Accept(IVisitor _visitor);
    }
}
