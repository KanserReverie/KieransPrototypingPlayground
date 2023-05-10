using System.Collections.Generic;
using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._007VisitorPattern.MotorBikePowerUps
{
    public class BikeController : MonoBehaviour, IBikeElement
    {
        private readonly List<IBikeElement> bikeElements = new List<IBikeElement>();

        private void Start()
        {
            bikeElements.Add(gameObject.AddComponent<BikeShield>());
            bikeElements.Add(gameObject.AddComponent<BikeWeapon>());
            bikeElements.Add(gameObject.AddComponent<BikeEngine>());
        }

        public void Accept(IVisitor visitor)
        {
            foreach (IBikeElement bikeElement in bikeElements)
            {
                bikeElement.Accept(visitor);
            }
        }
    }
}
