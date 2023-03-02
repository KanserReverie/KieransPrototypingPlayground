namespace PrototypingPlayground._001GameDevelopmentPatterns._004CommandPattern.MarbleReplaySystem.Commands
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