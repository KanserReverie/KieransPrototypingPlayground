using PrototypingPlayground.DumplingTesting.Throwing.ActivateCommands;
using UnityEngine;
namespace PrototypingPlayground.DumplingTesting.Throwing
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
            playerRigidbody.AddForce(playerForce);
        }
    }
}
