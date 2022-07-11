using System;
using UnityEngine;
namespace PrototypingPlayground.AbstractClasses
{
    public abstract class CubeBehaviour : MonoBehaviour
    {
        private static int cubeCount;
        protected float cubeLifeSpan = 1f;
        private float currentCubeLifeSpan;
        protected float cubeScale = 1f;

        public virtual void Setup(float _scale, float _lifeSpan)
        {
            cubeLifeSpan = _lifeSpan;
            cubeScale = _scale;
            cubeCount++;
            Debug.Log($"Cube {cubeCount}");
            gameObject.transform.localScale = new Vector3(cubeScale,cubeScale,cubeScale);
            Invoke(nameof(DeleteCube), cubeLifeSpan);
        }

        private void Start()
        {
            currentCubeLifeSpan = cubeLifeSpan;
        }
        private void Update()
        {
            currentCubeLifeSpan -= Time.deltaTime;
            if (currentCubeLifeSpan <= 0)
            {
                DeleteCube();
            }
        }
        private void DeleteCube()
        {
            Destroy(this);
        }
    }
}
