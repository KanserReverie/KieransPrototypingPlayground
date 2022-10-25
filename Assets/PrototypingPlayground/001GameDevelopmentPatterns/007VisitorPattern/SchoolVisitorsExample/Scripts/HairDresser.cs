using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._007VisitorPattern.SchoolVisitorsExample
{
    public class HairDresser : IVisitor
    {
        public string name { get; set; }
        
        public HairDresser(string _name)
        {
            name = _name;
        }
        public void Visit(IElement _element)
        {
            Kid kid = (Kid)_element;
            Debug.Log($"{this.name} gave a haircut to {kid.KidName}.");
        }
    }
}
