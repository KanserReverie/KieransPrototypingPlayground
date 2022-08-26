using PrototypingPlayground._1.GameDevelopmentPatterns.ObserverPattern.AbstractClasses;
using PrototypingPlayground._1.GameDevelopmentPatterns.ObserverPattern.FallingBall.AbstractClasses;
using UnityEngine;
namespace PrototypingPlayground._1.GameDevelopmentPatterns.ObserverPattern.FallingBall.FallingBallObservers
{
    public class CollisionUI : AbstractFallingBallObserverBehaviour
    {
        private Vector3 collisionLocation;
        private Quaternion collisionRotation;
        private float collisionStrength;
        private bool haveWeCollidedWithAnythingYet;
        
        private void Start()
        {
            AttachToFallingBallInScene();
        }

        private void OnGUI()
        {
            if (haveWeCollidedWithAnythingYet)
            {
                GUILayout.BeginVertical("box");
                GUILayout.Label($"Collision Location = {collisionLocation}");
                GUILayout.Label($"Collision Rotation = {collisionRotation}");
                GUILayout.Label($"Collision Strength = {collisionStrength}");
                GUILayout.EndHorizontal();
            }
        }
        
        public override void Notify(AbstractSubjectBehaviour _abstractSubjectBehaviour)
        {
            collisionLocation = fallingBall.lastCollision.location;
            collisionRotation = fallingBall.lastCollision.rotation;
            collisionStrength = fallingBall.lastCollision.strength;
            haveWeCollidedWithAnythingYet = fallingBall.haveWeCollidedWithAnythingYet;
        }
    }
}
