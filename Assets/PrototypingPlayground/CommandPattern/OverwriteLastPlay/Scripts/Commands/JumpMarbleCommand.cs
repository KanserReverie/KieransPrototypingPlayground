namespace PrototypingPlayground.CommandPattern.OverwriteLastPlay.Commands
{
    public class JumpMarbleCommand : AbstractMarbleCommand
    {
        public JumpMarbleCommand (MarbleController _marbleController) : base(_marbleController) { }
        
        public override void ExecuteCommand()
        {
            marbleController.Jump();
        }
    }
}