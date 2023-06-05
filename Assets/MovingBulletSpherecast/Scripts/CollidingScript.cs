using System;
using UnityEngine;

namespace MovingBulletSpherecast.Scripts
{
    public class CollidingScript : MonoBehaviour
    {
        [SerializeField] private float speed = 1f;
        [SerializeField] private int targetFrameRate = 5;
        [SerializeField] private bool tryingToMove = false;

        private void Start()
        {
            Debug.Log("Press Space to start simulation, sphere moves until object between current and next position");
        }

        private void Update()
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                transform.position = Vector3.zero;
                tryingToMove = tryingToMove == false;
                Application.targetFrameRate = targetFrameRate;
            }

            if (tryingToMove)
            {
                MoveSphere(speed * Time.deltaTime);
            }
        }

        private void MoveSphere(float distance)
        {
            Debug.Log("Move Sphere");
            
            if (Physics.SphereCast(transform.position, 0.5f, transform.forward * distance, out RaycastHit hit, distance))
            {
                Debug.Log($"Hit! hit.distance = {hit.distance}");
            }
            else
            {
                Debug.Log("Nothing in way"); 
                transform.position += transform.forward * distance;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position + ((transform.forward * speed)/targetFrameRate), 0.5f);
        }
    }
}
