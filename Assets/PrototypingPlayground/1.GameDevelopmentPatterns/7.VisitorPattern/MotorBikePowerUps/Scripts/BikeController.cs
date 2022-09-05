using System.Collections.Generic;
using UnityEngine;

namespace PrototypingPlayground._1.GameDevelopmentPatterns._7.VisitorPattern.MotorBikePowerUps
{
    public class BikeController : MonoBehaviour, IBikeElement
    {
        private List<IBikeElement> bikeElements;

        private void Start()
        {
            bikeElements.Add(gameObject.AddComponent<BikeShield>());
            bikeElements.Add(gameObject.AddComponent<BikeWeapon>());
            bikeElements.Add(gameObject.AddComponent<BikeEngine>());
        }

        public void Accept(IVisitor _visitor)
        {
            foreach (IBikeElement bikeElement in bikeElements)
            {
                bikeElement.Accept(_visitor);
            }
        }
    }
}
