using UnityEngine;
namespace PrototypingPlayground._003ProjectPrototypes.DumplingTesting.Teleporting.ActivateCommands
{
    public abstract class AbstractActivatePoint :  MonoBehaviour
    {
        public abstract AbstractActivateCommands GetActivePointCommand(Rigidbody playerRigidbody);
    }
}
