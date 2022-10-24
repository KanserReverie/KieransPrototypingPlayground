using PrototypingPlayground._003ProjectPrototypes.DumplingTesting.Teleporting.ActivateCommands;
using UnityEngine;
namespace PrototypingPlayground._003ProjectPrototypes.DumplingTesting.Teleporting
{
    public class TeleportActivatePoint : AbstractActivatePoint
    {
        [SerializeField] private Transform teleportPoint;
        
        public override AbstractActivateCommands GetActivePointCommand(Rigidbody _playerRigidbody)
        {
            return new TeleportCommand(_playerRigidbody, teleportPoint.position);
        }
    }
}
