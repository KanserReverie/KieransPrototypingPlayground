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
        public void Visit(VisitableExampleClassFirst visitableExample)
        {
            if (visitableExample.ThisUserType == VisitableExampleClassFirst.TypeOfUser.Human)
                visitableExample.DisplayingUI = false;
            else if (visitableExample.ThisUserType == VisitableExampleClassFirst.TypeOfUser.Computer)
                visitableExample.SporadicMovement = true;
        }

        public void Visit(VisitableExampleClassSecond visitableExample)
        {
            // Since this only effects human NPCs this will have no effect on goblins.
        }

        public void Visit(VisitableExampleClassThird visitableExample)
        {
            // Quest NPCs are invulnerable to everything.
            Debug.Log("This character is invulnerable.");
        }
    }
}