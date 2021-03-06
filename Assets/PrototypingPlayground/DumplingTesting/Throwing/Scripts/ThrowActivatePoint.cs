using PrototypingPlayground.DumplingTesting.Throwing.ActivateCommands;
using UnityEngine;
namespace PrototypingPlayground.DumplingTesting.Throwing
{
    public class ThrowActivatePoint : AbstractActivatePoint
    {
        [SerializeField] private Vector3 throwForce;

        public override AbstractActivateCommands GetActivePointCommand(Rigidbody _playerRigidbody)
        {
            return new ThrowCommand(_playerRigidbody, throwForce);
        }
    }
}
