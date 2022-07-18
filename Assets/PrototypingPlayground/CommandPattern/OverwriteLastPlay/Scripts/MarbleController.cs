using System;
using UnityEngine;
namespace PrototypingPlayground.CommandPattern.OverwriteLastPlay
{
    public class MarbleController : MonoBehaviour
    {
        private Rigidbody playerRigidbody;
        [SerializeField] private float jumpForce = 300f;
        [SerializeField] private float movementSpeed = 4f;
        private Vector3 spawnPoint;
        private Quaternion spawnRotation;

        public void Start()
        {
            playerRigidbody = GetComponent<Rigidbody>();
            spawnPoint = transform.position;
            spawnRotation = transform.rotation;
        }
        public void Jump()
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce);
        }
        public void HorizontalMovement(Vector2 _movementInput)
        {
            _movementInput.Normalize();
            Vector3 movementForce = Vector3.forward;
            movementForce.x += _movementInput.x;
            movementForce.z += _movementInput.y;
            playerRigidbody.AddForce(new Vector3(_movementInput.x,0,_movementInput.y)*movementSpeed);
        }

        public void SpawnMarble()
        {
            transform.position = spawnPoint;
            transform.rotation = spawnRotation;
            playerRigidbody.velocity = new Vector3(0,0,0);
            playerRigidbody.angularVelocity = new Vector3(0f,0f,0f);
        }
    }
}
