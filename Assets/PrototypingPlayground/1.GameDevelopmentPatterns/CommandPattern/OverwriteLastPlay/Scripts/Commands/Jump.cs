namespace PrototypingPlayground._1.GameDevelopmentPatterns.CommandPattern.OverwriteLastPlay.Scripts.Commands
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