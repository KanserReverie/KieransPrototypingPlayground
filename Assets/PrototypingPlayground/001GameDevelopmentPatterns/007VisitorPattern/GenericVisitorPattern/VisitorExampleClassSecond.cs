using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._007VisitorPattern.GenericVisitorPattern
{
    /// <summary>
    /// A visitor that can visit different classes.
    ///
    /// This is a crippling chill and will do 1 damage to all characters.
    /// </summary>
    public class VisitorExampleClassSecond : IVisitor
    {
        public void Visit(VisitableExampleClassFirst visitableExample)
        {
            visitableExample.Health--;
            if (visitableExample.Health <= 0)
            {
                visitableExample.Alive = false;
            }
        }

        public void Visit(VisitableExampleClassSecond visitableExample)
        {
            // Goblins die to any damage.
            visitableExample.Alive = false;
        }

        public void Visit(VisitableExampleClassThird visitableExample)
        {
            // Quest NPCs are invulnerable to everything.
            Debug.Log("This character is invulnerable.");
        }
    }
}