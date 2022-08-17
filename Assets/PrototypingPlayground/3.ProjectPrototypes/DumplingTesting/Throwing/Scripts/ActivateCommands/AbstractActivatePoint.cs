using UnityEngine;
namespace PrototypingPlayground._3.ProjectPrototypes.DumplingTesting.Throwing.Scripts.ActivateCommands
{
    public abstract class AbstractActivatePoint :  MonoBehaviour
    {
        public abstract AbstractActivateCommands GetActivePointCommand(Rigidbody _playerRigidbody);
    }
}
