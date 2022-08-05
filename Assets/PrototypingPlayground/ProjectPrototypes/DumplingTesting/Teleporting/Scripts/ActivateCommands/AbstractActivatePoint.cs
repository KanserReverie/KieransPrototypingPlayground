using UnityEngine;
namespace PrototypingPlayground.ProjectPrototypes.DumplingTesting.Teleporting.ActivateCommands
{
    public abstract class AbstractActivatePoint :  MonoBehaviour
    {
        public abstract AbstractActivateCommands GetActivePointCommand(Rigidbody _playerRigidbody);
    }
}
