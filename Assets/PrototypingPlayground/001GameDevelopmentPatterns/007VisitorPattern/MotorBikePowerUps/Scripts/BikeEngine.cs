using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._007VisitorPattern.MotorBikePowerUps
{
    public class BikeEngine : MonoBehaviour, IBikeElement
    {
        public float turboBoost = 25.0f; // km/h
        public float maxTurboBoost = 200.0f;

        private bool isTurboOn;
        private float defaultSpeed = 300.0f;

        public float CurrentSpeed
        {
            get
            {
                if (isTurboOn)
                {
                    return defaultSpeed + turboBoost;
                }
                else
                {
                    return defaultSpeed;
                }
            }
        }

        public void TurboToggle()
        {
            isTurboOn = !isTurboOn;
        }
        
        public void Accept(IVisitor _visitor)
        {
            _visitor.Visit(this);
        }

        private void OnGUI()
        {
            GUI.color = Color.cyan;
            
            GUI.Label(
                new Rect(125,20,200,20),
                $"Turbo Boost: {turboBoost}");
        }
    }
}
