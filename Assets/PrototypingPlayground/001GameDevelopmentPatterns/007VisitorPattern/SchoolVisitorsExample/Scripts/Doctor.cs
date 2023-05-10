using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._007VisitorPattern.SchoolVisitorsExample
{
    public class Doctor : IVisitor
    {
        public string Name { get; set; }
        public Doctor(string name)
        {
            Name = name;
        }
        
        public void Visit(IElement element)
        {
            Kid kid = (Kid)element;
            Debug.Log($"Doctor {this.Name} did the health checkup of the child: {kid.KidName}");
        }
    }
}