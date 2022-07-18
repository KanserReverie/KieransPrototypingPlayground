namespace PrototypingPlayground.CommandPattern.OverwriteLastPlay.Commands
{
    public class Jump : AbstractMarbleCommand
    {
        public Jump (MarbleController _marbleController) : base(_marbleController) { }
        
        public override void ExecuteCommand()
        {
            marbleController.Jump();
        }
    }
}