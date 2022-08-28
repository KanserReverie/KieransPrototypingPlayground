using UnityEngine;
namespace PrototypingPlayground._1.GameDevelopmentPatterns.ObserverPattern.FallingBall
{
    public class CollisionDetails
    {
        public readonly Collision collision;
        public readonly Material material;
        public readonly Vector3 location;
        public readonly Quaternion rotation;
        public readonly float strength;
        public readonly int instanceID;
        public readonly bool haveWeCollidedWithTheSameGameObject;
        
        public CollisionDetails(Collision _collision)
        {
            collision = _collision;
            strength = _collision.impulse.magnitude * Time.fixedDeltaTime;
            location = _collision.GetContact(0).point;
            rotation = _collision.transform.rotation;
            material = _collision.gameObject.GetComponentInChildren<Renderer>().material;
            instanceID = _collision.gameObject.GetInstanceID();

            if (material == null)
            {
                material = new Material(material);
            }
            haveWeCollidedWithTheSameGameObject = false;
        }

        public CollisionDetails(CollisionDetails _lastCollision, Collision _collision)
        {
            collision = _collision;
            strength = _collision.impulse.magnitude * Time.fixedDeltaTime;
            location = _collision.GetContact(0).point;
            rotation = _collision.transform.rotation;
            instanceID = _collision.gameObject.GetInstanceID();
            material = _collision.gameObject.GetComponentInChildren<Renderer>().material;

            if (material == null)
            {
                material = new Material(material);
            }

            haveWeCollidedWithTheSameGameObject = (_lastCollision.instanceID == instanceID);
        }
    }
}
