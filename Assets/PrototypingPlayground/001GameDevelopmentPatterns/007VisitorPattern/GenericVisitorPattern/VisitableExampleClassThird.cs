using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._007VisitorPattern.GenericVisitorPattern
{
    /// <summary>
    /// A class that can be visited.
    ///
    /// A Human Quest NPC.
    /// </summary>
    public class VisitableExampleClassThird : MonoBehaviour, IVisitable
    {
        internal bool alive = true;
        
        public void Accept(IVisitor _visitor)
        {
            _visitor.Visit(this);
        }
    }
}