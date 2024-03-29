using PrototypingPlayground._003ProjectPrototypes.DumplingTesting.Throwing.ActivateCommands;
using UnityEngine;
namespace PrototypingPlayground._003ProjectPrototypes.DumplingTesting.Throwing
{
    public class ThrowActivatePoint : AbstractActivatePoint
    {
        [SerializeField] private Vector3 throwForce;

        public override AbstractActivateCommands GetActivePointCommand(Rigidbody playerRigidbody)
        {
            return new ThrowCommand(playerRigidbody, throwForce);
        }
    }
}
