using System;
using UnityEngine;
namespace PrototypingPlayground.CommandPattern.OverwriteLastPlay
{
    public class MarbleController : MonoBehaviour
    {
        private Rigidbody playerRigidbody;
        [SerializeField] private float jumpForce = 10;

        public void Start()
        {
            playerRigidbody = GetComponent<Rigidbody>();
        }
        public void Jump()
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce);
        }
    }
}
