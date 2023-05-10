using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._007VisitorPattern.SchoolVisitorsExample
{
    public class HairDresser : IVisitor
    {
        public string Name { get; set; }
        
        public HairDresser(string name)
        {
            Name = name;
        }
        public void Visit(IElement element)
        {
            Kid kid = (Kid)element;
            Debug.Log($"{this.Name} gave a haircut to {kid.KidName}.");
        }
    }
}
