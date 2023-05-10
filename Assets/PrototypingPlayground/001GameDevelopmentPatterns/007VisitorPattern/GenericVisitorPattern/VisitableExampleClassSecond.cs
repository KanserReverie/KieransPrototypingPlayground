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
        internal bool Alive = true;

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}