namespace PrototypingPlayground._001GameDevelopmentPatterns._004CommandPattern.MarbleReplaySystem.Commands
{
    public class Respawn : AbstractMarbleCommand
    {
        public Respawn(MarbleController marbleController) : base(marbleController) { }
        
        public override void ExecuteCommand()
        {
            MarbleController.SpawnMarble();
        }
    }
}
