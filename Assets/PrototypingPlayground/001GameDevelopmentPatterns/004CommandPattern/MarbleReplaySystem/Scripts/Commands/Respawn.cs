namespace PrototypingPlayground._001GameDevelopmentPatterns._004CommandPattern.MarbleReplaySystem.Commands
{
    public class Respawn : AbstractMarbleCommand
    {
        public Respawn(MarbleController _marbleController) : base(_marbleController) { }
        
        public override void ExecuteCommand()
        {
            marbleController.SpawnMarble();
        }
    }
}
