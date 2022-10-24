namespace PrototypingPlayground._1.GameDevelopmentPatterns._7.VisitorPattern.SchoolVisitorsExample
{
    public class Kid : IElement
    {
        public string KidName { get; set; }
        
        public Kid(string _name)
        {
            KidName = _name;
        }
        
        public void Accept(IVisitor _visitor)
        {
            _visitor.Visit(this);
        }
    }
}
