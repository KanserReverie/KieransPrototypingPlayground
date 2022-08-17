namespace PrototypingPlayground._1.GameDevelopmentPatterns.CommandPattern.OverwriteLastPlay.Scripts.Commands
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
