using UnityEngine;
namespace PrototypingPlayground._2.BasicConcepts.AbstractClasses.Scripts
{
    public class SpawnableCube : CubeBehaviour
    {
        public SpawnableCube(float _cubeLifeSpan, float _cubeScale)
        {
            cubeLifeSpan = _cubeLifeSpan;
            cubeScale = _cubeScale;
        }

        public override void Setup(float _scale, float _lifeSpan)
        {
            gameObject.AddComponent<BoxCollider>();
            gameObject.AddComponent<Rigidbody>();
            base.Setup(_scale, _lifeSpan);
        }
    }
}