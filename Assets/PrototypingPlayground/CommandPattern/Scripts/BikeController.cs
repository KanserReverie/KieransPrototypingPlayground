using UnityEngine;
namespace PrototypingPlayground.CommandPattern
{
    public class BikeController : MonoBehaviour
    {
        public enum TurnDirection { Left = -1, Right = 1 }
        
        public void ToggleTurbo()
        {
            throw new System.NotImplementedException();
        }
        public void Turn(TurnDirection directionToTurn)
        {
            throw new System.NotImplementedException();
        }
    }
}
