using System;
using UnityEngine;
namespace PrototypingPlayground.CommandPattern.OverwriteLastPlay
{
    public class MarbleController : MonoBehaviour
    {
        private Rigidbody playerRigidbody;
        [SerializeField] private float jumpForce = 300f;
        [SerializeField] private float movementSpeed = 4f;

        public void Start()
        {
            playerRigidbody = GetComponent<Rigidbody>();
        }
        public void Jump()
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce);
        }
        public void HorizontalMovement(Vector2 _movementInput)
        {
            _movementInput.Normalize();
            playerRigidbody.AddForce(new Vector3(_movementInput.x,0,_movementInput.y));
        }
    }
}
