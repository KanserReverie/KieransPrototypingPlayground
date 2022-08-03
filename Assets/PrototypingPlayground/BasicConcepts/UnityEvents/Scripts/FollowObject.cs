using System;
using UnityEngine;
namespace PrototypingPlayground.UnityEvents.Scripts
{
    public class FollowObject : MonoBehaviour
    {
        [SerializeField] private Transform transformToFollow;
        private void LateUpdate()
        {
            transform.position = transformToFollow.position;
        }
    }
}
