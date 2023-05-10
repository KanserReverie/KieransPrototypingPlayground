using UnityEngine;
namespace PrototypingPlayground._002BasicConcepts.AbstractClasses
{
    public class SpawnableCube : CubeBehaviour
    {
        public SpawnableCube(float cubeLifeSpan, float cubeScale)
        {
            CubeLifeSpan = cubeLifeSpan;
            CubeScale = cubeScale;
        }

        public override void Setup(float scale, float lifeSpan)
        {
            gameObject.AddComponent<BoxCollider>();
            gameObject.AddComponent<Rigidbody>();
            base.Setup(scale, lifeSpan);
        }
    }
}