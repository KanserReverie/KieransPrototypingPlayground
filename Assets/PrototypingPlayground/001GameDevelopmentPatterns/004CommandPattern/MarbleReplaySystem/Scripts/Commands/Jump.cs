namespace PrototypingPlayground._001GameDevelopmentPatterns._004CommandPattern.MarbleReplaySystem.Commands
{
    public class Jump : AbstractMarbleCommand
    {
        public Jump (MarbleController marbleController) : base(marbleController) { }
        
        public override void ExecuteCommand()
        {
            MarbleController.Jump();
        }
    }
}