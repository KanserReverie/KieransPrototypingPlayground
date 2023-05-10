using UnityEngine;
namespace PrototypingPlayground._002BasicConcepts.AbstractClasses
{
    public abstract class CubeBehaviour : MonoBehaviour
    {
        private static int cubeCount;
        protected float CubeLifeSpan = 1f;
        private float currentCubeLifeSpan;
        protected float CubeScale = 1f;

        public virtual void Setup(float scale, float lifeSpan)
        {
            CubeLifeSpan = lifeSpan;
            CubeScale = scale;
            cubeCount++;
            Debug.Log($"Cube {cubeCount}");
            gameObject.transform.localScale = new Vector3(CubeScale,CubeScale,CubeScale);
            Invoke(nameof(DeleteCube), CubeLifeSpan);
        }

        private void Start()
        {
            currentCubeLifeSpan = CubeLifeSpan;
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
            Destroy(this.gameObject);
        }
    }
}
