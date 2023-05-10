using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._008StrategyPattern.FighterDrones
{
    public class Drone : MonoBehaviour
    {
        // Ray parameters
        private RaycastHit hit;
        private Vector3 rayDirection;
        private float rayAngle = -45.0f;
        private float rayDistance = 15.0f;

        // Movement parameters
        public float speed = 1.0f;
        public float maxHeight = 5.0f;
        public float weavingDistance = 1.5f;
        public float fallbackDistance = 20.0f;
        public float diagonalDistance = 10.0f;
        

        void Start() 
        {
            rayDirection = transform.TransformDirection(Vector3.back) * rayDistance;

            rayDirection = Quaternion.Euler(rayAngle, 0.0f, 0f) * rayDirection;
        }

        public void ApplyStrategy(IDroneStrategy strategy) 
        {
            strategy.ImplementStrategy(this);
        }

        void Update() 
        {
            Debug.DrawRay(transform.position, rayDirection, Color.blue);

            if (Physics.Raycast(transform.position, rayDirection, out hit, rayDistance)) 
            {
                if (hit.collider)
                {
                    Debug.DrawRay(transform.position, rayDirection, Color.green);
                }
            }
        }
    }
}
