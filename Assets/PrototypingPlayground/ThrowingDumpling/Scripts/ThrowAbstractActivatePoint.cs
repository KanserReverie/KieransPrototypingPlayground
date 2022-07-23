using UnityEngine;
namespace PrototypingPlayground.ThrowingDumpling
{
    public class ThrowAbstractActivatePoint : AbstractActivatePoint
    {
        [SerializeField] private Vector3 throwForce;

        public override AbstractActivateCommands GetActivePointCommand(Rigidbody _playerRigidbody)
        {
            return new ThrowCommand(_playerRigidbody, throwForce);
        }
    }
}
