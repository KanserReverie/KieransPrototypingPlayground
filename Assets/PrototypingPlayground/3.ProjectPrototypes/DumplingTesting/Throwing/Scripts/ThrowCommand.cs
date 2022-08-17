using PrototypingPlayground._3.ProjectPrototypes.DumplingTesting.Throwing.Scripts.ActivateCommands;
using UnityEngine;
namespace PrototypingPlayground._3.ProjectPrototypes.DumplingTesting.Throwing.Scripts
{
    public class ThrowCommand : AbstractActivateCommands
    {
        private Rigidbody playerRigidbody;
        private Vector3 playerForce;
        
        public ThrowCommand(Rigidbody _playerRigidbody, Vector3 _playerForce)
        {
            playerRigidbody = _playerRigidbody;
            playerForce = _playerForce;
        }
        
        public override void ExecuteCommand()
        {
            playerRigidbody.velocity = Vector3.zero;
            playerRigidbody.angularVelocity = Vector3.zero;
            playerRigidbody.AddForce(playerForce);
        }
    }
}
