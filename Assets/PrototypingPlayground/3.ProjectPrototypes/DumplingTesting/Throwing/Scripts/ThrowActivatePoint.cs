using PrototypingPlayground._3.ProjectPrototypes.DumplingTesting.Throwing.Scripts.ActivateCommands;
using UnityEngine;
namespace PrototypingPlayground._3.ProjectPrototypes.DumplingTesting.Throwing.Scripts
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
