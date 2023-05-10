using PrototypingPlayground._003ProjectPrototypes.DumplingTesting.Teleporting.ActivateCommands;
using UnityEngine;
namespace PrototypingPlayground._003ProjectPrototypes.DumplingTesting.Teleporting
{
    public class TeleportCommand : AbstractActivateCommands
    {
        private Rigidbody playerRigidbody;
        private Vector3 teleportLocation;
        
        public TeleportCommand(Rigidbody playerRigidbody, Vector3 teleportLocation)
        {
            this.playerRigidbody = playerRigidbody;
            this.teleportLocation = teleportLocation;
        }
        
        public override void ExecuteCommand()
        {
            playerRigidbody.velocity = Vector3.zero;
            playerRigidbody.angularVelocity = Vector3.zero;
            playerRigidbody.MovePosition(teleportLocation);
            playerRigidbody.velocity = Vector3.zero;
            playerRigidbody.angularVelocity = Vector3.zero;
        }
    }
}
