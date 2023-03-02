using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._004CommandPattern.MarbleReplaySystem.Commands
{
    public class HorizontalMovement : AbstractMarbleCommand
    {
        private Vector2 movementDirection;
        public HorizontalMovement(MarbleController _marbleController, Vector2 _movementDirection) : base(_marbleController)
        {
            movementDirection = _movementDirection;
        }
        
        public override void ExecuteCommand()
        {
            marbleController.HorizontalMovement(movementDirection);
        }
    }
}
