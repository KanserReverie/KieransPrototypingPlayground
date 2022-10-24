using UnityEngine;
namespace PrototypingPlayground._003ProjectPrototypes.DumplingTesting.Throwing.ActivateCommands
{
    public abstract class AbstractActivatePoint :  MonoBehaviour
    {
        public abstract AbstractActivateCommands GetActivePointCommand(Rigidbody _playerRigidbody);
    }
}
