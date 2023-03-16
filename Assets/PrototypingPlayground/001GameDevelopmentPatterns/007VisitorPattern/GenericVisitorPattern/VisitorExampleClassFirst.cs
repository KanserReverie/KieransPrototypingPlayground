using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._007VisitorPattern.GenericVisitorPattern
{
    /// <summary>
    /// First Example Visitor.
    ///
    /// A curse that effects all Normal Humans.
    ///
    /// "Human" Players this will turn off their UI || "Computer" Players this will have sporadic movement. 
    /// </summary>
    public class VisitorExampleClassFirst : IVisitor
    { 
        // The curse effect for different Humans.
        public void Visit(VisitableExampleClassFirst _visitableExample)
        {
            if (_visitableExample.typeOfUser == VisitableExampleClassFirst.TypeOfUser.Human)
                _visitableExample.displayingUI = false;
            else if (_visitableExample.typeOfUser == VisitableExampleClassFirst.TypeOfUser.Computer)
                _visitableExample.sporadicMovement = true;
        }

        public void Visit(VisitableExampleClassSecond _visitableExample)
        {
            // Since this only effects human NPCs this will have no effect on goblins.
        }

        public void Visit(VisitableExampleClassThird _visitableExample)
        {
            // Quest NPCs are invulnerable to everything.
           Debug.Log("This character is invulnerable.");
        }
    }
}