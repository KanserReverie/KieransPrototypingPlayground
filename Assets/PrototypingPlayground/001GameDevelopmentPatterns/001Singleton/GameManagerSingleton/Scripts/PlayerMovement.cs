using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._001Singleton.GameManagerSingleton
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody playerRigidBody;
        [SerializeField][Range(1,2)] private float speed = 1.5f;
        
        private void Start()
        {
            playerRigidBody = GetComponentInChildren<Rigidbody>();
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.W)) playerRigidBody.AddForce(-Vector3.forward*speed) ;
            if (Input.GetKey(KeyCode.A)) playerRigidBody.AddForce(Vector3.right*speed);
            if (Input.GetKey(KeyCode.S)) playerRigidBody.AddForce(Vector3.forward*speed);
            if (Input.GetKey(KeyCode.D)) playerRigidBody.AddForce(-Vector3.right*speed);
        }
    }
}
