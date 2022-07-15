using UnityEngine;
namespace PrototypingPlayground.CommandPattern.OverwriteLastPlay.Commands
{
    public class HorizontalMovementMarbleCommand : AbstractMarbleCommand
    {
        public HorizontalMovementMarbleCommand(MarbleController _marbleController) : base(_marbleController) { }
        
        public override void ExecuteCommand(Vector2 _movementInput)
        {
            marbleController.HorizontalMovement(_movementInput);
        }
    }
}
