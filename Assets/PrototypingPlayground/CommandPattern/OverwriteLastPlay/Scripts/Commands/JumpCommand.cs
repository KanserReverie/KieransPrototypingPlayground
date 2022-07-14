namespace PrototypingPlayground.CommandPattern.OverwriteLastPlay.Commands
{
    public class JumpCommand : MarbleCommand
    {
        public JumpCommand (MarbleController _marbleController) : base(_marbleController) { }
        
        public override void ExecuteCommand()
        {
            marbleController.Jump();
        }
    }
}