using System.Collections.Generic;
namespace PrototypingPlayground._001GameDevelopmentPatterns._007VisitorPattern.SchoolVisitorsExample
{
    public class School
    {
        private static List<IElement> elements;
        static School()
        {
            elements = new List<IElement>
            {
                new Kid("Ram"),
                new Kid("Sara"),
                new Kid("Pam")
            };
        }
        public void PerformOperation(IVisitor _visitor)
        {
            foreach (IElement kid in elements)
            {
                kid.Accept(_visitor);
            }
        }
    }
}
