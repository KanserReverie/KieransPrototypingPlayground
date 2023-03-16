using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._007VisitorPattern.GenericVisitorPattern
{
    /// <summary>
    /// A class that can be visited.
    ///
    /// A Small Goblin. 
    /// </summary>
    public class VisitableExampleClassSecond : MonoBehaviour, IVisitable
    {
        internal bool alive = true;

        public void Accept(IVisitor _visitor)
        {
            _visitor.Visit(this);
        }
    }
}