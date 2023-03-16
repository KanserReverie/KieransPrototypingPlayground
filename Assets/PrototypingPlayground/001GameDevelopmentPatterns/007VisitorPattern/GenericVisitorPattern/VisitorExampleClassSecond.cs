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
        public void Visit(VisitableExampleClassFirst _visitableExample)
        {
            _visitableExample.health--;
            if (_visitableExample.health <= 0)
            {
                _visitableExample.alive = false;
            }
        }

        public void Visit(VisitableExampleClassSecond _visitableExample)
        {
            // Goblins die to any damage.
            _visitableExample.alive = false;
        }

        public void Visit(VisitableExampleClassThird _visitableExample)
        {
            // Quest NPCs are invulnerable to everything.
            Debug.Log("This character is invulnerable.");
        }
    }
}