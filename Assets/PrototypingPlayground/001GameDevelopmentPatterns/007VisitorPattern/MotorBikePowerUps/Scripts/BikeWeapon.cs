using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._007VisitorPattern.MotorBikePowerUps
{
    public class BikeWeapon : MonoBehaviour, IBikeElement
    {
        [Header("Range")]
        public int range = 5;
        public int maxRange = 25;
        [Header("Strength")]
        public float strength = 25.0f;
        public float maxStrength = 50.0f;

        public void Fire()
        {
            Debug.Log("Weapon Fired!!");
        }
        
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        private void OnGUI()
        {
            GUI.color = Color.cyan;
            
            GUI.Label(
                new Rect(125, 40, 200,20),
                $"Weapon Range: {range}");
            
            GUI.Label(
                new Rect(125,60,200,20),
                $"Weapon Strength: {strength}");
        }
    }
}
