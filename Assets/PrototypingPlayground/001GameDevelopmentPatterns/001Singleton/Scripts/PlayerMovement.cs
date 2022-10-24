using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._001Singleton
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody _playerRigidBody;
        [SerializeField][Range(1,2)] private float speed = 1.5f;
        // Start is called before the first frame update
        void Start()
        {
            _playerRigidBody = GetComponentInChildren<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.W)) _playerRigidBody.AddForce(-Vector3.forward*speed) ;
            if (Input.GetKey(KeyCode.A)) _playerRigidBody.AddForce(Vector3.right*speed);
            if (Input.GetKey(KeyCode.S)) _playerRigidBody.AddForce(Vector3.forward*speed);
            if (Input.GetKey(KeyCode.D)) _playerRigidBody.AddForce(-Vector3.right*speed);
        }
    }
}
