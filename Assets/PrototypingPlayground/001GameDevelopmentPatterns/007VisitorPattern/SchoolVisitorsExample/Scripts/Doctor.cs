using System;
namespace PrototypingPlayground._001GameDevelopmentPatterns._007VisitorPattern.SchoolVisitorsExample
{
    public class Doctor : IVisitor
    {
        public string Name { get; set; }
        public Doctor(string _name)
        {
            Name = _name;
        }
        
        public void Visit(IElement _element)
        {
            Kid kid = (Kid)_element;
            Console.WriteLine("Doctor: " + this.Name+ " did the health checkup of the child: "+ kid.KidName);
        }
    }
}