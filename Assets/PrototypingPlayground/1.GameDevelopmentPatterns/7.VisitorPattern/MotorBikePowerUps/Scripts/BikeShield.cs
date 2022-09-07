using System;
using UnityEngine;
namespace PrototypingPlayground._1.GameDevelopmentPatterns._7.VisitorPattern.MotorBikePowerUps
{
    public class BikeShield : MonoBehaviour, IBikeElement
    {
        public float health = 50.0f; // Percentage

        public float Damage(float _damage)
        {
            health -= _damage;
            return health;
        }

        public void Accept(IVisitor _visitor)
        {
            _visitor.Visit(this);
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
