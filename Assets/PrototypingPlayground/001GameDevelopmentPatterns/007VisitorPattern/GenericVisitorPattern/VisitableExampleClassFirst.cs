using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._007VisitorPattern.GenericVisitorPattern
{
    /// <summary>
    /// A class that can be visited.
    ///
    /// A Normal Human.
    /// </summary>
    public class VisitableExampleClassFirst : MonoBehaviour, IVisitable
    {
        // We are using internal instead of private so that visitors can modify but not other classes outside.
        internal bool Alive = true;
        
        internal TypeOfUser ThisUserType;
        internal bool DisplayingUI = true;
        internal bool SporadicMovement = false;
        
        internal int Health = 10;
        
        public enum TypeOfUser { Human, Computer }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
        
        
    }
}