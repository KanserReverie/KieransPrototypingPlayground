using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._007VisitorPattern.MotorBikePowerUps
{
    public class BikeShield : MonoBehaviour, IBikeElement
    {
        public float health = 50.0f; // Percentage

        public float Damage(float damage)
        {
            health -= damage;
            return health;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        private void OnGUI()
        {
            GUI.color = Color.cyan;
            
            GUI.Label(
                new Rect(125,0,200,20),
                $"Shield Health: {health}");
        }
    }
}
