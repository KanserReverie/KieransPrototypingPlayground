namespace PrototypingPlayground._1.GameDevelopmentPatterns._4.CommandPattern.OverwriteLastPlay.Commands
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
