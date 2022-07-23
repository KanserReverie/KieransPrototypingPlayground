using PrototypingPlayground.TeleportingDumpling.ActivateCommands;
using UnityEngine;
namespace PrototypingPlayground.TeleportingDumpling
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
