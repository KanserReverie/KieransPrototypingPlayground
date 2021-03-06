using UnityEngine;
namespace PrototypingPlayground.CommandPattern.OverwriteLastPlay.Commands
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
