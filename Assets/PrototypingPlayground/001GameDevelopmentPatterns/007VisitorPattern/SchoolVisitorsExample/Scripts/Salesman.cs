using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._007VisitorPattern.SchoolVisitorsExample
{
    class Salesman : IVisitor
    {
        private string Name { get; set; }
        
        public Salesman(string name)
        {
            Name = name;
        }
        
        public void Visit(IElement element)
        {
            Kid kid = (Kid)element;
            Debug.Log($"Salesman: {this.Name} gave the school bag to the child: {kid.KidName}");
        }
    }
}