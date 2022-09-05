using UnityEngine;
namespace PrototypingPlayground._1.GameDevelopmentPatterns._7.VisitorPattern.MotorBikePowerUps
{
    public class BikeWeapon : MonoBehaviour, IBikeElement
    {
        public int range;
        public int maxRange;
        public float strength;
        public float maxStrength;
        public void Accept(IVisitor _visitor)
        {
            throw new System.NotImplementedException();
        }
    }
}
