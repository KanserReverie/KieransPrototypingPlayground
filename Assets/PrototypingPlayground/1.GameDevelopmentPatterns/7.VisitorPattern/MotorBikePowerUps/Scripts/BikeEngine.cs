using UnityEngine;
namespace PrototypingPlayground._1.GameDevelopmentPatterns._7.VisitorPattern.MotorBikePowerUps
{
    public class BikeEngine : MonoBehaviour, IBikeElement
    {
        public float turboBoost;
        public float maxTurboBoost;

        public void Accept(IVisitor _visitor)
        {
            throw new System.NotImplementedException();
        }
    }
}
