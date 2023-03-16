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
        internal bool alive = true;
        
        internal TypeOfUser typeOfUser;
        internal bool displayingUI = true;
        internal bool sporadicMovement = false;
        
        internal int health = 10;
        
        public enum TypeOfUser { Human, Computer }
        public void Accept(IVisitor _visitor)
        {
            _visitor.Visit(this);
        }
        
        
    }
}