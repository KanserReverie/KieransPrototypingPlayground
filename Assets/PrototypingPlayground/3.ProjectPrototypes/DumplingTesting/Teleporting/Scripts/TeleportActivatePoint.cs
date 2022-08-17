using PrototypingPlayground._3.ProjectPrototypes.DumplingTesting.Teleporting.Scripts.ActivateCommands;
using UnityEngine;
namespace PrototypingPlayground._3.ProjectPrototypes.DumplingTesting.Teleporting.Scripts
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
