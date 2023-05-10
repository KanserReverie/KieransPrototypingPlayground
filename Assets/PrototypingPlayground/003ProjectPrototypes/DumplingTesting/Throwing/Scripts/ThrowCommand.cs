using PrototypingPlayground._003ProjectPrototypes.DumplingTesting.Throwing.ActivateCommands;
using UnityEngine;
namespace PrototypingPlayground._003ProjectPrototypes.DumplingTesting.Throwing
{
    public class ThrowCommand : AbstractActivateCommands
    {
        private Rigidbody playerRigidbody;
        private Vector3 playerForce;
        
        public ThrowCommand(Rigidbody playerRigidbody, Vector3 playerForce)
        {
            this.playerRigidbody = playerRigidbody;
            this.playerForce = playerForce;
        }
        
        public override void ExecuteCommand()
        {
            playerRigidbody.velocity = Vector3.zero;
            playerRigidbody.angularVelocity = Vector3.zero;
            playerRigidbody.AddForce(playerForce);
        }
    }
}
