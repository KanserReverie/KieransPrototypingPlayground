using PrototypingPlayground._001GameDevelopmentPatterns._006ObserverPattern.FallingBall.AbstractClasses;
using PrototypingPlayground._001GameDevelopmentPatterns._006ObserverPattern.GenericObserverPattern;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace PrototypingPlayground._001GameDevelopmentPatterns._006ObserverPattern.FallingBall.FallingBallObservers
{
    public class CollisionUI : AbstractFallingBallObserverBehaviour
    {
        private Vector3 collisionLocation;
        private Quaternion collisionRotation;
        private float collisionStrength;
        private bool haveWeCollidedWithAnythingYet;
        private bool haveWeCollidedWithTheSameGameObject;
        
        private void Start()
        {
            AttachToFallingBallInScene();
        }
        
        private void OnGUI()
        {
            if (haveWeCollidedWithAnythingYet)
            {
                GUILayout.BeginVertical("box");
                GUILayout.Label($"Current Scene = {SceneManager.GetActiveScene().name}");
                GUILayout.Label($"Collision Location = {collisionLocation}");
                GUILayout.Label($"Collision Rotation = {collisionRotation}");
                GUILayout.Label($"Collision Strength = {collisionStrength}");
                GUILayout.Label($"Have we collided with the same GameObject = {haveWeCollidedWithTheSameGameObject}");
                GUILayout.EndHorizontal();
            }
            else
            {
                GUILayout.BeginVertical("box");
                GUILayout.Label($"Current Scene = {SceneManager.GetActiveScene().name}");
                GUILayout.EndHorizontal();
            }
        }
        
        public override void Notify(AbstractSubjectBehaviour abstractSubjectBehaviour)
        {
            collisionLocation = FallingBall.LastCollision.Location;
            collisionRotation = FallingBall.LastCollision.Rotation;
            collisionStrength = FallingBall.LastCollision.Strength;
            haveWeCollidedWithAnythingYet = FallingBall.haveWeCollidedWithAnythingYet;
            haveWeCollidedWithTheSameGameObject = FallingBall.LastCollision.HaveWeCollidedWithTheSameGameObject;
        }
    }
}
