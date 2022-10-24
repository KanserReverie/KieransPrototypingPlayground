using System;

namespace PrototypingPlayground._1.GameDevelopmentPatterns._7.VisitorPattern.SchoolVisitorsExample
{
    class Salesman : IVisitor
    {
        public string Name { get; set; }
        public Salesman(string _name)
        {
            Name = _name;
        }
        public void Visit(IElement _element)
        {
            Kid kid = (Kid)_element;
            Console.WriteLine("Salesman: " + this.Name + " gave the school bag to the child: " + kid.KidName);
        }
    }
}