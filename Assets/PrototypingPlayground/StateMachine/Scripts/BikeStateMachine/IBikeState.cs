using PrototypingPlayground.StateMachine.BikeStateMachine;
using UnityEngine;
namespace PrototypingPlayground.StateMachine.BikeStateMachine
{
    public interface IBikeState
    {
        public void Handle(BikeController controller)
        {
            
        }
    }
}
