using UnityEngine;
namespace PrototypingPlayground._1.GameDevelopmentPatterns._7.VisitorPattern.MotorBikePowerUps
{
    public class BikeShield : MonoBehaviour, IBikeElement
    {
        public float health;

        public void Accept(IVisitor _visitor)
        {
            throw new System.NotImplementedException();
        }
    }
}
