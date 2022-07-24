using PrototypingPlayground.DumplingTesting.Teleporting.ActivateCommands;
using UnityEngine;
namespace PrototypingPlayground.DumplingTesting.Teleporting
{
    public class TeleportCommand : AbstractActivateCommands
    {
        private Rigidbody playerRigidbody;
        private Vector3 teleportLocation;
        
        public TeleportCommand(Rigidbody _playerRigidbody, Vector3 _teleportLocation)
        {
            playerRigidbody = _playerRigidbody;
            teleportLocation = _teleportLocation;
        }
        
        public override void ExecuteCommand()
        {
            playerRigidbody.MovePosition(teleportLocation);
        }
    }
}
