using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._004CommandPattern.MarbleReplaySystem.Commands
{
    public class HorizontalMovement : AbstractMarbleCommand
    {
        private Vector2 movementDirection;
        public HorizontalMovement(MarbleController marbleController, Vector2 movementDirection) : base(marbleController)
        {
            this.movementDirection = movementDirection;
        }
        
        public override void ExecuteCommand()
        {
            MarbleController.HorizontalMovement(movementDirection);
        }
    }
}
