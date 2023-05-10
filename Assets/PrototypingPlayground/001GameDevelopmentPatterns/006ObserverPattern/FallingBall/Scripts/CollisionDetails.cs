using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._006ObserverPattern.FallingBall
{
    public class CollisionDetails
    {
        public readonly Collision Collision;
        public readonly Material Material;
        public readonly Vector3 Location;
        public readonly Quaternion Rotation;
        public readonly float Strength;
        public readonly int InstanceID;
        public readonly bool HaveWeCollidedWithTheSameGameObject;
        
        public CollisionDetails(Collision collision)
        {
            Collision = collision;
            Strength = collision.impulse.magnitude * Time.fixedDeltaTime;
            Location = collision.GetContact(0).point;
            Rotation = collision.transform.rotation;
            Material = collision.gameObject.GetComponentInChildren<Renderer>().material;
            InstanceID = collision.gameObject.GetInstanceID();

            if (Material == null)
            {
                Material = new Material(Material);
            }
            HaveWeCollidedWithTheSameGameObject = false;
        }

        public CollisionDetails(CollisionDetails lastCollision, Collision collision)
        {
            Collision = collision;
            Strength = collision.impulse.magnitude * Time.fixedDeltaTime;
            Location = collision.GetContact(0).point;
            Rotation = collision.transform.rotation;
            InstanceID = collision.gameObject.GetInstanceID();
            Material = collision.gameObject.GetComponentInChildren<Renderer>().material;

            if (Material == null)
            {
                Material = new Material(Material);
            }

            HaveWeCollidedWithTheSameGameObject = (lastCollision.InstanceID == InstanceID);
        }
    }
}
